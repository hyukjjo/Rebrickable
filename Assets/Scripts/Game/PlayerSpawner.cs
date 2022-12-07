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
        playerData = new PlayerData();
        playerData._gold = 0;
        playerData._level = 0;
        PlayerData.SetPlayerData(playerData);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPlayer()
    {
        var player = GameManager.Instance.PlayerPrefab;
        if (player != null)
        {
            Instantiate(player, transform.position, Quaternion.identity);
        }
    }
}