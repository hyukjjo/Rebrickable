using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : Singleton<MonsterSpawner>
{
    [SerializeField]
    private int _startingMonsterCount = 0;
    [SerializeField]
    private float _spawnDelay = 0f;
    [SerializeField]
    private string _currentSpawnTargetName = string.Empty;
    //[SerializeField]
    //private List<Monster> _monsterList = new List<Monster>();

    private Coroutine _coroutine;

    // Start is called before the first frame update
    void Start()
    {
        //InitSpawnMonster();
        GameManager.Instance.RoundStart += InitSpawnMonster;
    }

    // Update is called once per frame                     
    void Update()
    {

    }

    void InitSpawnMonster()
    {
        //for (int i = 0; i < _startingMonsterCount; i++)
        //{
        //    SpawnMonster();
        //}

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(SpawnMonsterCoroutine());
        }
    }

    public void SpawnMonster()
    {
        _currentSpawnTargetName = "Monster_Lv" + GameManager.Instance._currentRoundLevel.ToString();
        var monster = ObjectPoolManager.Instance.Spawn(_currentSpawnTargetName);
        monster.transform.position = new Vector2(Random.Range(-20, 20), Random.Range(-20, 20));
    }

    public void StopSpawnMonster()
    {
        StopCoroutine(_coroutine);
        _coroutine = null;
    }

    private IEnumerator SpawnMonsterCoroutine()
    {
        while (true)
        {
            SpawnMonster();
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}