using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField]
    private int _value = 0;
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameManager.Instance.currentPlayer.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            _player.GainGold(_value);
            ObjectPoolManager.Instance.Despawn(GetComponent<PoolObject>());
        }
    }
}
