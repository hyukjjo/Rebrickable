using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : Singleton<MonsterSpawner>
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
            SpawnMonster();
        }
    }

    public void SpawnMonster()
    {
        var monster = ObjectPoolManager.Instance.Spawn("Monster_Lv1");
        monster.transform.position = new Vector2(Random.Range(-20, 20), Random.Range(-20, 20));
    }
}
