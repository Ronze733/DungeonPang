using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float _spawnTime;
    public float _curTime;
    public Transform[] _spawnPoint;
    public GameObject _monster;

    void Update()
    {
        if (_curTime >= _spawnTime)
        {
            int x = Random.Range(0, _spawnPoint.Length);
          SpawnMonster(x);
        }
        _curTime += Time.deltaTime;
    }

    public void SpawnMonster(int ranNum)
    {
        _curTime = 0;
        Instantiate(_monster, _spawnPoint[ranNum].position, Quaternion.identity);
    }
}
