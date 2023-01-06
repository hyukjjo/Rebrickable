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
    private Vector3 _mousePosition = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 _playerPosition;
    private Coroutine _coroutine;

    private void Start()
    {
        _cam = Camera.main;
        _player = GameManager.Instance.currentPlayer;

        _coroutine = StartCoroutine(_skillCoroutine());
    }

    private void Update()
    {
        _mousePosition = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        _playerPosition = _player.transform.position;
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
    }

    public void ResetSkill()
    {
        ObjectPoolManager.Instance.Despawn(GetComponent<PoolObject>());
    }

    private IEnumerator _skillCoroutine()
    {
        float time = 1f;
        float elapse = 0f;
        Vector3 targetPosition = _mousePosition - _playerPosition;
        Vector3 targetDirection = targetPosition / targetPosition.magnitude;

        transform.position = _playerPosition;

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
