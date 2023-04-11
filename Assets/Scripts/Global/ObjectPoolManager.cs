using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeyType = System.String;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    [SerializeField]
    private List<PoolObjectData> _poolObjectDataList =  new List<PoolObjectData>();

    private Dictionary<KeyType, PoolObject> _sampleDictionary;

    private Dictionary<KeyType, PoolObjectData> _dataDictionary;

    private Dictionary<KeyType, Queue<PoolObject>> _poolDictionary;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        int leng = _poolObjectDataList.Count;
        if (leng == 0)
            return;

        _sampleDictionary = new Dictionary<KeyType, PoolObject>(leng);
        _dataDictionary = new Dictionary<KeyType, PoolObjectData>(leng);
        _poolDictionary = new Dictionary<KeyType, Queue<PoolObject>>(leng);

        foreach (var item in _poolObjectDataList)
        {
            Register(item);
        }
    }

    private void Register(PoolObjectData data)
    {
        if(_poolDictionary.ContainsKey(data.Key))
        {
            return;
        }

        GameObject sample = Instantiate(data.ObjectPrefab);

        if(!sample.TryGetComponent(out PoolObject po))
        {
            po = sample.AddComponent<PoolObject>();
            po.Key = data.Key;
        }
        sample.SetActive(false);

        Queue<PoolObject> pool = new Queue<PoolObject>(data.MaxObjectCount);

        for(int i = 0; i < data.InitialObjectCount; i++)
        {
            PoolObject clone = po.Clone();
            pool.Enqueue(clone);
        }

        _sampleDictionary.Add(data.Key, po);
        _dataDictionary.Add(data.Key, data);
        _poolDictionary.Add(data.Key, pool);
    }

    public PoolObject Spawn(KeyType key)
    {
        // Ű�� �������� �ʴ� ��� null ����
        if (!_poolDictionary.TryGetValue(key, out var pool))
        {
            return null;
        }

        PoolObject po;

        // 1. Ǯ�� ��� �ִ� ��� : ��������
        if (pool.Count > 0)
        {
            po = pool.Dequeue();
        }
        // 2. ��� ���� ��� ���÷κ��� ����
        else
        {
            po = _sampleDictionary[key].Clone();
        }

        po.Activate();

        return po;
    }

    public void Despawn(PoolObject po)
    {
        // Ű�� �������� �ʴ� ��� ����
        if (!_poolDictionary.TryGetValue(po.Key, out var pool))
        {
            return;
        }

        KeyType key = po.Key;

        // 1. Ǯ�� ���� �� �ִ� ��� : Ǯ�� �ֱ�
        if (pool.Count < _dataDictionary[key].MaxObjectCount)
        {
            pool.Enqueue(po);
            po.Deactivate();
        }
        // 2. Ǯ�� �ѵ��� ���� �� ��� : �ı��ϱ�
        else
        {
            Destroy(po.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}