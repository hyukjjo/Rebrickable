using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSkill : MonoBehaviour
{
    [SerializeField]
    private SkillController _skill;

    public bool IsDetroyedAfterCollision = true;
    public float RepeatRate;
    public float MoveSpeed;
    public float Damage;

    // Start is called before the first frame update
    public virtual void Start()
    {
        InvokeRepeating(nameof(UseSkill), 0f, RepeatRate);
    }

    public virtual void UseSkill()
    {
        ObjectPoolManager.Instance.Spawn(_skill.name);
        _skill.InitSkill(MoveSpeed, Damage, IsDetroyedAfterCollision);
    }

    public virtual void StopSkill()
    {
        
    }
}
