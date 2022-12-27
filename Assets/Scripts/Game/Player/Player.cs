using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPlayerUniqueSkill
{
    public void UsePlayerUniqueSkill();
}

public class Player : MonoBehaviour
{
    public int Hp;
    public int Dam;
    public int Def;
    public int Spd;

    private float _colliderRange = 3.0f;
    private SphereCollider _collider;

    public virtual void Start()
    {
        //PlayerInit();
    }

    public virtual void PlayerInit()
    {
        Debug.Log("Player Init!");
        _collider = gameObject.AddComponent<SphereCollider>();
        _collider.radius = _colliderRange * 0.5f;
    }

    public void UpgradeColliderRange(float value = 0f)
    {
        if(value == 0)
        {
            _collider.radius += 0.1f;
        }
        else
        {
            _collider.radius += value;
        }
    }
}
