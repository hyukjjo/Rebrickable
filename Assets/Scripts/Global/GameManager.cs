using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class GameManager : Singleton<GameManager>
{
    public bool LoadSceneReady = false;
    public GameObject PlayerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveDataAndExitGame()
    {
        Debug.Log("Save data and exit this game.");
    }
}
