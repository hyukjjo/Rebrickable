using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Red : Player
{
    private float _moveSpeed = 0.01f;

    public override void PlayerInit()
    {
        base.PlayerInit();
        Debug.Log("Player_Red Init!");
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Debug.Log("Player_Red Start");

      //  PlayerInit();
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
    }
}