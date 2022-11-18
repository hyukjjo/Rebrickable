using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Black : Player
{
    private float _moveSpeed = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player_Black Start");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.up * _moveSpeed, Space.World);
    }
}
