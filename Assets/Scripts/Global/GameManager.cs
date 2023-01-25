using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class GameManager : Singleton<GameManager>
{
    [HideInInspector]
    public bool LoadSceneReady = false;
    [HideInInspector]
    public GameObject PlayerPrefab;

    private Player currentPlayer;

    public void SetPlayer(Player player)
    {
        currentPlayer = player;
    }

    public Player GetPlayer()
    {
        return currentPlayer;
    }

    public void SaveDataAndExitGame(int gold = 0, int exp = 0)
    {
        Debug.Log("Save data and exit this game.");

        if (gold == 0 && exp == 0)
        {
            return;
        }
        else
        {
            PlayerData.SetPlayerData(new PlayerData()
            {
                _gold = gold + PlayerData.GetPlayerData()._gold,
                _exp = exp + PlayerData.GetPlayerData()._exp
            });
        }
    }
}