using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public int Hp;
    public int Dam;
    public int Def;
    public int Spd;

    private float _colliderRadiusSize = 1.5f;

    public virtual void PlayerInit()
    {
        var collider = gameObject.AddComponent<SphereCollider>();
        collider.radius = _colliderRadiusSize;
    }

    public virtual void Start()
    {
        PlayerInit();
    }
}
