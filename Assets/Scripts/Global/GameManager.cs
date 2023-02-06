using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

[System.Serializable]
public class ProbabilityData
{

}

public class GameManager : Singleton<GameManager>
{
    [HideInInspector]
    public bool LoadSceneReady = false;
    [HideInInspector]
    public GameObject PlayerPrefab;

    private Player currentPlayer;

    public void KillAllMonstersInField()
    {
        Debug.Log("Kill All Monsters!!");
    }

    public void PlayerSpeedUp()
    {
        Debug.Log("Player Speed Level Up!!");
    }

    public void PlayerMagnetUp()
    {
        Debug.Log("Player Magnet Level Up!!");
    }

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