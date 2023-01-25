using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Lv1 : Monster
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void Die()
    {
        base.Die();
    }

    public override void HitByPlayerSkill(float dam)
    {
        base.HitByPlayerSkill(dam);
    }

    //public override void OnTriggerEnter2D(Collider2D collision)
    //{
    //    base.OnTriggerEnter2D(collision);
    //}
}