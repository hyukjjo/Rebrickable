using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Monster : MonoBehaviour
{
    public float Hp;
    public float Dam;
    public float Def;
    public float Spd;
    public int Exp;

    private Player _player;
    [SerializeField]
    private Image _hpImage;
    [SerializeField]
    private TextMeshProUGUI _damageText;
    private float _totalHp;
    private Animator _animator;

    // Start is called before the first frame update
    public virtual void Start()
    {
        // Monster CSV Data �����ͼ� �������ִ� �κ�
        _player = GameManager.Instance.GetPlayer();
        _totalHp = Hp;
        _animator = GetComponent<Animator>();
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
        _hpImage.fillAmount = Hp / _totalHp;
        _animator.SetTrigger("Hit");
        _damageText.text = dam.ToString();

        if (Hp <= 0)
        {
            ResetMonster();
            Die();
        }
    }

    public virtual void Die()
    {
        _player.GainExp(Exp);
        ObjectPoolManager.Instance.Despawn(GetComponent<PoolObject>());
        ObjectPoolManager.Instance.Spawn("Gold").transform.position = transform.position;
        MonsterSpawner.Instance.SpawnMonster();
    }

    private void ResetMonster()
    {
        Hp = _totalHp;
        _hpImage.fillAmount = 1f;
    }

    public virtual void OnCollisionStay2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Player"))
        { 
            _player.HitByPlayerMonster(Dam);
        }
    }
}