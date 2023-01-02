using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Black : Player, IPlayerUniqueSkill
{
    public List<PlayerSkill> PlayerSkillSlot = new List<PlayerSkill>();
    private Vector3 _mousePosition;

    public override void PlayerInit()
    {
        base.PlayerInit();
        Debug.Log("Player_Black Init!");
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Debug.Log("Player_Black Start");

        ActiveSkills();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.up * Spd, Space.World);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.down * Spd, Space.World);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Spd, Space.World);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Spd, Space.World);

    }

    public void ActiveSkills()
    {
        foreach (var item in PlayerSkillSlot)
        {
            GameObject.Instantiate<PlayerSkill>(item);
        }
        
    }

    
}
