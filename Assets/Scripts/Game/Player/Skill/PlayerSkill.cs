using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSkillData
{
    public bool IsDetroyedAfterCollision = true;
    public float RepeatRate;
    public float MoveSpeed;
    public float Damage;
}

[System.Serializable]
public class PlayerSkill : MonoBehaviour
{
    [SerializeField]
    private SkillController _skill;

    [SerializeField]
    private PlayerSkillData _playerSkillData;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(UseSkill), 0f, _playerSkillData.RepeatRate);
    }

    private void UseSkill()
    {
        var skill = ObjectPoolManager.Instance.Spawn(_skill.name);
        skill.GetComponent<SkillController>().InitSkill(_playerSkillData.MoveSpeed, _playerSkillData.Damage, _playerSkillData.IsDetroyedAfterCollision);
    }

    private void StopSkill()
    {
        
    }
}
