using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using System;

[System.Serializable]
public class ProbabilityData
{

}

public enum GameState
{
    WAIT = 0,
    ROUND,
    PAUSE
}

public class GameManager : Singleton<GameManager>
{
    [HideInInspector]
    public bool IsCharacterSelected = false;
    public GameObject PlayerPrefab;
    [HideInInspector]
    public int _currentRoundLevel = 1;
    [SerializeField]
    private GameState _currentState;
    [SerializeField]
    private float _currentRoundPlayTime = 0f;
    [SerializeField]
    private float _roundLimitTime = 60.0f;
    private Coroutine _roundCoroutine;
    private int _maxRoundLevel = 5;
    [SerializeField]
    private Player _currentPlayer;

    #region 게임 플레이에 관련된 Actions
    public Action RoundStart =      () => { Debug.Log("Stage has started!"); };
    public Action PlayerDead =      () => { Debug.Log("Player is dead!"); };
    public Action RoundLevelUp =    () => { };
    public Action RoundPause =      () => { Debug.Log("Stage has paused!"); };
    public Action KillAllMonsters = () => { Debug.Log("All mosters in field are dead!"); };
    public Action PlayerSpeedUp =   () => { Debug.Log("Player speed up!"); };
    public Action PlayerMagnetUp =  () => { Debug.Log("Player magnet up!"); };
    #endregion

    private void Start()
    {
        InitAllActions();
    }

    /// <summary>
    /// GameManager 클래스에 정의된 Action 함수들을 Internally 초기화
    /// </summary>
    public void InitAllActions()
    {
        //
        RoundStart += () => 
        {
            _currentState = GameState.ROUND;
        };
        //
        RoundLevelUp += () =>
        {
            if (_currentRoundLevel >= _maxRoundLevel)
            {
                Debug.Log("Current stage Level has already reached max level.");
                return;
            }
            Debug.Log("Stage Level Up!!");
            _currentRoundLevel++;
            _currentRoundPlayTime = 0f;
        };
        //
        RoundPause += () =>
        {
            //StagePause action에 팝업 관련 이벤트 등록 필요함
        };
    }

    private void Update()
    {
        PlayGame();
    }

    private void PlayGame()
    {
        switch (_currentState)
        {
            case GameState.WAIT:
                break;
            case GameState.ROUND:
                _currentRoundPlayTime += Time.deltaTime;

                if(_currentRoundPlayTime >= _roundLimitTime)
                {
                    RoundLevelUp();
                }
                break;
            case GameState.PAUSE:
                break;
            default:
                break;
        }
    }

    public void SetPlayer(Player player)
    {
        _currentPlayer = player;
    }

    public Player GetPlayer()
    {
        return _currentPlayer;
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