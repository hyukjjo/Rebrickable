using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    private float _moveSpeed;
    private float _damage;
    private bool _isDestroyedAfterCollision = false;

    private Camera _cam;
    private GameObject _player;
    private Coroutine _coroutine;

    private void Awake()
    {
        _cam = Camera.main;
        _player = GameManager.Instance.currentPlayer;
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    public void InitSkill(float spd, float dam, bool bDestroyed)
    {
        _moveSpeed = spd;
        _damage = dam;
        _isDestroyedAfterCollision = bDestroyed;

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

    private IEnumerator _skillCoroutine()
    {
        float time = 1f;
        float elapse = 0f;

        var mousePosition = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        var playerPosition = _player.transform.position;

        Vector3 targetPosition = mousePosition - playerPosition;
        Vector3 targetDirection = targetPosition / targetPosition.magnitude;

        transform.position = playerPosition;

        while (elapse <= time)
        {
            transform.Translate(targetDirection * _moveSpeed, Space.World);
            elapse += Time.deltaTime;
            yield return null;
        }

        ObjectPoolManager.Instance.Despawn(GetComponent<PoolObject>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            var monster = collision.GetComponent<Monster>();
            monster.HitByPlayerSkill(_damage);

            if(_isDestroyedAfterCollision == true)
            {
                ObjectPoolManager.Instance.Despawn(GetComponent<PoolObject>());
            }
        }
    }
}
