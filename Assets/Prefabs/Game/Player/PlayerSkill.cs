using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public GameObject SkillPrefab;
    public bool IsDetroyedAfterCollision = true;
    public float MoveSpeed;
    public float Damage;

    private Vector3 _mousePosition = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 _playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(UseSkill), 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        _playerPosition = GameManager.Instance.currentPlayer.transform.position;
    }

    private IEnumerator PlayerSkillCoroutine()
    {
        float time = 1f;
        float elapse = 0f;
        Vector3 targetPosition = _mousePosition - _playerPosition;
        Vector3 targetDirection = targetPosition / targetPosition.magnitude;

        var skill = GameObject.Instantiate(SkillPrefab);

        skill.transform.position = _playerPosition;

        while (elapse <= time)
        {
            skill.transform.Translate(targetDirection * MoveSpeed, Space.World);
            elapse += Time.deltaTime;
            yield return null;
        }

        DestroyImmediate(skill);
    }

    public void UseSkill()
    {
        StartCoroutine(PlayerSkillCoroutine());
    }
}
