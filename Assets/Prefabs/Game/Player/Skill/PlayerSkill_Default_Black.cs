using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill_Default_Black : PlayerSkill
{
    private PoolObject skill;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public override IEnumerator PlayerSkillCoroutine()
    {
        float time = 1f;
        float elapse = 0f;
        Vector3 targetPosition = _mousePosition - _playerPosition;
        Vector3 targetDirection = targetPosition / targetPosition.magnitude;

        skill = ObjectPoolManager.Instance.Spawn("PlayerSkill_Default_Black");

        skill.transform.position = _playerPosition;

        while (elapse <= time)
        {
            skill.transform.Translate(targetDirection * MoveSpeed, Space.World);
            elapse += Time.deltaTime;
            yield return null;
        }

        StopSkill();
    }

    public override void UseSkill()
    {
        base.UseSkill();
    }

    public override void StopSkill()
    {
        base.StopSkill();
        ObjectPoolManager.Instance.Despawn(skill);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
