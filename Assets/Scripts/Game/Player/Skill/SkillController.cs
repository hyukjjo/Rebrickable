using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillController : MonoBehaviour
{
    [HideInInspector]
    public PlayerSkillData _playerSkillData;
    [HideInInspector]
    public Camera _cam;
    [HideInInspector]
    public GameObject _player;
    [HideInInspector]
    public Coroutine _coroutine;

    public virtual void Awake()
    {
        _cam = Camera.main;
        _player = GameManager.Instance.currentPlayer;
    }

    public virtual void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    public virtual void InitSkill(float spd, float dam, bool bDestroyed)
    {
        _playerSkillData = new PlayerSkillData();
        _playerSkillData.MoveSpeed = spd;
        _playerSkillData.Damage = dam;
        _playerSkillData.IsDetroyedAfterCollision = bDestroyed;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(_skillCoroutine());
    }

    public void ResetSkill()
    {
        ObjectPoolManager.Instance.Despawn(GetComponent<PoolObject>());
    }

    public abstract IEnumerator _skillCoroutine();

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            var monster = collision.GetComponent<Monster>();
            monster.HitByPlayerSkill(_playerSkillData.Damage);

            if(_playerSkillData.IsDetroyedAfterCollision == true)
            {
                ObjectPoolManager.Instance.Despawn(GetComponent<PoolObject>());
            }
        }
    }
}
