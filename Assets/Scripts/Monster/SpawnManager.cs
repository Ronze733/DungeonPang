using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] _spawnPoint;

    [SerializeField]
    private GameObject _character = null;

    private float _timer;
    private float _gamePlayTime;

    private bool _spawnedFourthMonster;

    private void Awake()
    {
        _spawnPoint = GetComponentsInChildren<Transform>();
    }

    private void Start()
    {
        _gamePlayTime = 0.0f;
        _spawnedFourthMonster = false;
    }

    private void Update()
    {
        Vector3 pos = _character.transform.position;
        this.transform.position = pos;

        _timer += Time.deltaTime;
        _gamePlayTime += Time.deltaTime;

        float spawnInterval = GetSpawnInterval(_gamePlayTime);

        if (_timer > spawnInterval)
        {
            Spawn();
            _timer = 0;
        }
    }

    private int GetMonsterSpawnRange()
    {
        if (_gamePlayTime <= 10.0f)
        {
            return 1; // 1~10초 동안의 스폰 범위는 1 (1번째 몬스터만)
        }
        else if (_gamePlayTime <= 20.0f)
        {
            return 2; // 10~20초 동안의 스폰 범위는 2 (2번째 몬스터만)
        }
        else if (_gamePlayTime <= 30.0f)
        {
            return 3; // 20~30초 동안의 스폰 범위는 3 (3번째 몬스터만)
        }
        else
        {
            return 4; // 30초 이후의 스폰 범위는 4 (4번째 몬스터만)
        }
    }

    private void Spawn()
    {
        if (_gamePlayTime <= 30.0f)
        {
            int monsterSpawnRange = GetMonsterSpawnRange();
            GameObject monster = GameManager.Instance.Pool.Get(monsterSpawnRange - 1);
            monster.transform.position = _spawnPoint[UnityEngine.Random.Range(1, _spawnPoint.Length)].position;
        }
        else
        {
            if (!_spawnedFourthMonster)
            {
                int spawnIndex = UnityEngine.Random.Range(1, _spawnPoint.Length);
                GameObject monster = GameManager.Instance.Pool.Get(3); // 4번째 몬스터는 3번 인덱스에 해당
                monster.transform.position = _spawnPoint[spawnIndex].position;
                _spawnedFourthMonster = true;
            }
        }
    }

    private float GetSpawnInterval(float gameTime)
    {
        if (gameTime <= 10.0f)
        {
            return 1.0f; // 1~10초 동안의 스폰 간격은 0.2초
        }
        else
        {
            // 10초 이후의 스폰 간격을 조정하려면 이 값을 조절하면 됩니다.
            return 0.2f; // 10초 이후부터는 1초에 한 번씩 스폰
        }
    }
}    

