using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Hp;
    public float Dam;
    public float Def;
    public float Spd;

    // Start is called before the first frame update
    public virtual void Start()
    {
        // Monster CSV Data 가져와서 셋팅해주는 부분
    }

    public virtual void Update()
    {

    }

    public virtual void HitByPlayerSkill(float dam)
    {
        Hp -= dam;

        if(Hp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        ObjectPool.ReturnMonster(this);
        ObjectPool.TakeGold().transform.position = transform.position;
    }
}
//    public virtual void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.CompareTag("PlayerSkill"))
//        {
//            Die();
//        }
//    }
//}
