using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InitSpawnMonster();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitSpawnMonster()
    {
        for(int i = 0; i < 10; i++)
        {
            var monster = ObjectPool.TakeMonster();
            monster.transform.position = new Vector2(Random.Range(0, 25), Random.Range(0, 25));
        }
    }
}
