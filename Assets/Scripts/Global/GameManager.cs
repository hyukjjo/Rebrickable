using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using System;

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

    #region 게임 플레이에 관련된 Actions
    public Action StageStart =   () => { Debug.Log("Stage has started!"); };
    public Action PlayerDead =   () => { Debug.Log("Player is dead..."); };
    public Action StageLevelUp = () => { };
    public Action StagePause =   () => { Debug.Log("Stage has paused!"); };
    #endregion

    private void Awake()
    {
        InitAllActions();
    }

    /// <summary>
    /// GameManager 클래스에 정의된 Action 함수들을 Internally 초기화
    /// </summary>
    public void InitAllActions()
    {
        //
        StageStart += () => 
        {
            _stageCoroutine = StartCoroutine(CheckStageTimeCoroutine());
        };
        //
        StageLevelUp += () =>
        {
            if (_currentStageLevel >= _maxStageLevel)
            {
                Debug.Log("Current stage Level has already reached max level.");
                return;
            }
            Debug.Log("Stage Level Up!!");
            _currentStageLevel++;
            _currentStagePlayTime = 0f;
            _stageCoroutine = StartCoroutine(CheckStageTimeCoroutine());
        };
        //
        StagePause += () =>
        {
            //StagePause action에 팝업 관련 이벤트 등록 필요함
        };
    }

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