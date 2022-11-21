using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Red : Player, IPlayerMove
{
    private float _moveSpeed = 0.001f;

    void IPlayerMove.PlayerMove()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player_Red Start");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.up * _moveSpeed, Space.World);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.down * _moveSpeed, Space.World);
    }
}
