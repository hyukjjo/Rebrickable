using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSkill : MonoBehaviour
{
    public bool IsDetroyedAfterCollision = true;
    public float RepeatRate;
    public float MoveSpeed;
    public float Damage;

    [HideInInspector]
    public Vector3 _mousePosition = new Vector3(0.1f, 0.1f, 0.1f);
    [HideInInspector]
    public Vector3 _playerPosition;

    private Camera _cam;
    private GameObject _player;
    private Coroutine _coroutine;

    // Start is called before the first frame update
    public virtual void Start()
    {
        _cam = Camera.main;
        _player = GameManager.Instance.currentPlayer;

        InvokeRepeating(nameof(UseSkill), 0f, RepeatRate);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        _mousePosition = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        _playerPosition = _player.transform.position;
    }

    public abstract IEnumerator PlayerSkillCoroutine();

    public virtual void UseSkill()
    {
        _coroutine = StartCoroutine(PlayerSkillCoroutine());
    }

    public virtual void StopSkill()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}
