using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSkill : MonoBehaviour
{
    [SerializeField]
    private SkillController _skill;

    public bool IsDetroyedAfterCollision = true;
    public float RepeatRate;
    public float MoveSpeed;
    public float Damage;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(UseSkill), 0f, RepeatRate);
    }

    private void UseSkill()
    {
        var skill = ObjectPoolManager.Instance.Spawn(_skill.name);
        skill.GetComponent<SkillController>().InitSkill(MoveSpeed, Damage, IsDetroyedAfterCollision);
    }

    private void StopSkill()
    {
        
    }
}
