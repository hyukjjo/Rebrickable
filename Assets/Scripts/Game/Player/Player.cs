using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPlayerUniqueSkill
{
    public void ActiveSkills();
}

public class Player : MonoBehaviour
{
    public float Hp;
    public float Dam;
    public float Def;
    public float Spd;

    private float _colliderRange = 3.0f;
    private SphereCollider _collider;
    private int _gainedGold = 0;
    private int _gainedExp = 0;

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

    public void GainGold(int value)
    {
        _gainedGold += value;
    }

    public void GainExp(int value)
    {
        _gainedExp += value;
    }

    private void OnApplicationQuit()
    {
        GameManager.Instance.SaveDataAndExitGame(_gainedGold, _gainedExp);
    }
}
