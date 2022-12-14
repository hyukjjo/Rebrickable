using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    [SerializeField]
    private GameObject _poolingItemPrefab;
    [SerializeField]
    private GameObject _poolingGoldPrefab;
    [SerializeField]
    private GameObject _poolingMonsterPrefab;
    private Queue<Item> _poolingItemQueue = new Queue<Item>();
    private Queue<Gold> _poolingGoldQueue = new Queue<Gold>();
    private Queue<Monster> _poolingMonsterQueue = new Queue<Monster>();

    private void Awake()
    {
        InitItem(10);
        InitGold(10);
        InitMonster(20);
    }

    private void InitMonster(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            _poolingMonsterQueue.Enqueue(CreateNewMonster());
        }
    }

   

    private void InitItem(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            _poolingItemQueue.Enqueue(CreateNewItem());
        }
    }

    private void InitGold(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            _poolingGoldQueue.Enqueue((CreateNewGold()));
        }
    }

    private Item CreateNewItem()
    {
        var newObj = Instantiate(_poolingItemPrefab).GetComponent<Item>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static Item TakeItem()
    {
        if (Instance._poolingItemQueue.Count > 0)
        {
            var obj = Instance._poolingItemQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewItem();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    

    public static void ReturnItem(Item obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance._poolingItemQueue.Enqueue(obj);
    }

    private Gold CreateNewGold()
    {
        var newObj = Instantiate(_poolingGoldPrefab).GetComponent<Gold>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static Gold TakeGold()
    {
        if (Instance._poolingGoldQueue.Count > 0)
        {
            var obj = Instance._poolingGoldQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewGold();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnGold(Gold obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance._poolingGoldQueue.Enqueue(obj);
    }

    private Monster CreateNewMonster()
    {
        var newObj = Instantiate(_poolingMonsterPrefab).GetComponent<Monster>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static Monster TakeMonster()
    {
        if (Instance._poolingMonsterQueue.Count > 0)
        {
            var obj = Instance._poolingMonsterQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewMonster();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnMonster(Monster obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance._poolingMonsterQueue.Enqueue(obj);
    }
}