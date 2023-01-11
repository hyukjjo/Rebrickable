using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class GameManager : Singleton<GameManager>
{
    public bool LoadSceneReady = false;
    public GameObject PlayerPrefab;
    public GameObject currentPlayer;

    private void Start()
    {
        Debug.Log("!!#");
    }

    public void SaveDataAndExitGame(int gold = 0, int exp = 0)
    {
        Debug.Log("Save data and exit this game.");

        PlayerData.SetPlayerData(new PlayerData() {_gold = gold, _level = exp });
    }
}
