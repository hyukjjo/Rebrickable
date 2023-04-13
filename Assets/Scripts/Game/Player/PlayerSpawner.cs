using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
        //playerData = new PlayerData();
        //playerData._gold = 0;
        //playerData._level = 0;
        //PlayerData.SetPlayerData(playerData);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPlayer()
    {
        var playerPrefab = GameManager.Instance.PlayerPrefab;
        var player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        GameManager.Instance.SetPlayer(player.GetComponent<Player>());
        PlayerCam.Instance.SetPlayerCam(player);
    }
}