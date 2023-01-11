using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Hp;
    public float Dam;
    public float Def;
    public float Spd;

    private GameObject _player;

    // Start is called before the first frame update
    public virtual void Start()
    {
        // Monster CSV Data 가져와서 셋팅해주는 부분
        _player = GameManager.Instance.currentPlayer;
    }

    public virtual void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        Vector3 dir = (_player.transform.position - transform.position).normalized;
        transform.position += Time.deltaTime * dir * Spd;
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
        ObjectPoolManager.Instance.Despawn(GetComponent<PoolObject>());
        ObjectPoolManager.Instance.Spawn("Gold").transform.position = transform.position;
        MonsterSpawner.Instance.SpawnMonster();
    }
}