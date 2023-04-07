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

    [SerializeField]
    private float _currentStagePlayTime = 0f;
    private float _stageLimitTime = 60.0f;
    private Coroutine _stageCoroutine;
    [SerializeField]
    private int _currentStageLevel = 1;
    private int _maxStageLevel = 5;
    [SerializeField]
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

    private void StageLevelUp()
    {
        if (_currentStageLevel >= _maxStageLevel)
        {
            Debug.Log("MAX STAGE LEVEL!");
            return;
        }

        Debug.Log("Stage Level Up!!");
        _currentStageLevel++;
        _currentStagePlayTime = 0f;
        _stageCoroutine = StartCoroutine(CheckStageTimeCoroutine());
    }

    public void SetPlayer(Player player)
    {
        currentPlayer = player;
    }

    public Player GetPlayer()
    {
        return currentPlayer;
    }

    public void StartStage()
    {
        Debug.Log("Stage Start!!");
        _stageCoroutine = StartCoroutine(CheckStageTimeCoroutine());
    }

    private IEnumerator CheckStageTimeCoroutine()
    {
        while(_currentStagePlayTime < _stageLimitTime)
        {
            _currentStagePlayTime += Time.deltaTime;
            yield return null;
        }

        if (_stageCoroutine != null)
            _stageCoroutine = null;

        StageLevelUp();
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