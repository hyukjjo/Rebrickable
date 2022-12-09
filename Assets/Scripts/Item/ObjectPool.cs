using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    [SerializeField]
    private GameObject _poolingObjectPrefab;
    private Queue<Item> _poolingObjectQueue = new Queue<Item>();

    private void Awake()
    {
        Init(10);
    }

    private void Init(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            _poolingObjectQueue.Enqueue(CreateNewItem());
        }
    }

    private Item CreateNewItem()
    {
        var newObj = Instantiate(_poolingObjectPrefab).GetComponent<Item>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static Item TakeItem()
    {
        if (Instance._poolingObjectQueue.Count > 0)
        {
            var obj = Instance._poolingObjectQueue.Dequeue();
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
        Instance._poolingObjectQueue.Enqueue(obj);
    }
}