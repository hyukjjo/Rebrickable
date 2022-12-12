using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Black : Player, IPlayerMove
{
    private float _moveSpeed = 0.001f;

    public override void PlayerInit()
    {
        base.PlayerInit();
    }

    void IPlayerMove.PlayerMove()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Debug.Log("Player_Black Start");

        PlayerInit();
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
