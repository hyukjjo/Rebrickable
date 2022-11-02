using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class GameManager : Singleton<GameManager>
{
    public bool LoadSceneReady = false;
    public GameObject PlayerPrefab;

    public void SaveDataAndExitGame()
    {
        Debug.Log("Save data and exit this game.");
    }
}
