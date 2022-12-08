using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Player : MonoBehaviour
{
    public int Hp;
    public int Dam;
    public int Def;
    public int Spd;

    public abstract void PlayerInit();
}
