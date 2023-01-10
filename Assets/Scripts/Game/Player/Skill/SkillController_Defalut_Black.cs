using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController_Defalut_Black : SkillController
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void InitSkill(float spd, float dam, bool bDestroyed)
    {
        base.InitSkill(spd, dam, bDestroyed);
    }

    public override IEnumerator _skillCoroutine()
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
            transform.Translate(targetDirection * _playerSkillData.MoveSpeed, Space.World);
            elapse += Time.deltaTime;
            yield return null;
        }

        ObjectPoolManager.Instance.Despawn(GetComponent<PoolObject>());
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D (collision);
    }
}
