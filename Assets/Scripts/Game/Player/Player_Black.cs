using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Black : Player, IPlayerUniqueSkill
{
    public GameObject UniqueSkillPrefab;

    private float _moveSpeed = 0.01f;

    private Vector2 _mousePosition;

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

        InvokeRepeating(nameof(UsePlayerUniqueSkill), 0f, 0.5f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.up * _moveSpeed, Space.World);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.down * _moveSpeed, Space.World);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * _moveSpeed, Space.World);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * _moveSpeed, Space.World);

        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void UsePlayerUniqueSkill()
    {
        StartCoroutine(PlayerSkillCoroutine());
        
    }

    private IEnumerator PlayerSkillCoroutine()
    {
        float time = 1f;
        float elapse = 0f;
        Vector2 targetPosition = _mousePosition;

        var skill = GameObject.Instantiate(UniqueSkillPrefab);
        skill.transform.position = transform.position;

        while (elapse <= time)
        {
            skill.transform.Translate(targetPosition * _moveSpeed, Space.World);
            elapse += Time.deltaTime;
            yield return null;
        }

        DestroyImmediate(skill);
    }
}
