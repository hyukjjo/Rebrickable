using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSkill : MonoBehaviour
{
    public bool IsDetroyedAfterCollision = true;
    public float RepeatRate;
    public float MoveSpeed;
    public float Damage;

    public Vector3 _mousePosition = new Vector3(0.1f, 0.1f, 0.1f);
    public Vector3 _playerPosition;

    // Start is called before the first frame update
    public virtual void Start()
    {
        InvokeRepeating(nameof(UseSkill), 0f, RepeatRate);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        _playerPosition = GameManager.Instance.currentPlayer.transform.position;
    }

    public abstract IEnumerator PlayerSkillCoroutine();

    public virtual void UseSkill()
    {
        StartCoroutine(PlayerSkillCoroutine());
    }

    public virtual void StopSkill()
    {
        StopCoroutine(PlayerSkillCoroutine());
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            var monster = collision.GetComponent<Monster>();
            monster.HitByPlayerSkill(Damage);

            if (IsDetroyedAfterCollision == true)
            {
                StopSkill();
            }
        }
    }
}
