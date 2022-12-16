using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : Singleton<PlayerCam>
{
    private GameObject _player;

    void Update()
    {
        if(_player != null)
        {
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10);
        }
    }

    public void SetPlayerCam(GameObject player)
    {
        _player = player;
    }
}
