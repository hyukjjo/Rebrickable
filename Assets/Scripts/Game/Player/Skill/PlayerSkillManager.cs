
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : Singleton<PlayerSkillManager>
{
    [SerializeField]
    private List<PlayerSkill> _playerSkillSlot = new List<PlayerSkill>();

    public void ActivePlayerSkills()
    {
        for(int i = 0; i < _playerSkillSlot.Count; i++)
        {
            var skill = Instantiate(_playerSkillSlot[i]);
            skill.transform.SetParent(transform, false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}