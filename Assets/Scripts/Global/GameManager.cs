using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class GameManager : Singleton<GameManager>
{
    public bool LoadSceneReady = false;
    public GameObject PlayerPrefab;

    private int _gold;
    private int _level;

    public void SaveGold(int gold)
    {
        _gold = gold;
    }

    public void SaveLevel(int level)
    {
        _level = level;
    }

    public void SaveDataAndExitGame()
    {
        Debug.Log("Save data and exit this game.");

        PlayerData.SetPlayerData(new PlayerData() {_gold = _gold, _level = _level });
    }
}
