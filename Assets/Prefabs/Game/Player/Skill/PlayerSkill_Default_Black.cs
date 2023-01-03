using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill_Default_Black : PlayerSkill
{
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

        var skill = GameObject.Instantiate(SkillPrefab).GetComponent<PlayerSkillController>();

        skill.transform.position = _playerPosition;

        while (elapse <= time)
        {
            skill.transform.Translate(targetDirection * MoveSpeed, Space.World);
            elapse += Time.deltaTime;
            yield return null;
        }

        DestroyImmediate(skill);
    }

    public override void StopSkill()
    {
        base.StopSkill();
        DestroyImmediate(skill);
    }
}
