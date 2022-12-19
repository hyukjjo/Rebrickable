using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int Hp;
    public int Dam;
    public int Def;
    public int Spd;

    // Start is called before the first frame update
    public virtual void Start()
    {
        // Monster CSV Data 가져와서 셋팅해주는 부분
    }

    public virtual void Update()
    {
        //if(Hp <= 0)
        //{
        //    Die();
        //}
    }

    public virtual void Die()
    {
        ObjectPool.ReturnMonster(this);
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Die();
        }
    }
}
