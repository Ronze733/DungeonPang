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
            return 1; // 1~10�� ������ ���� ������ 1 (1��° ���͸�)
        }
        else if (_gamePlayTime <= 20.0f)
        {
            return 2; // 10~20�� ������ ���� ������ 2 (2��° ���͸�)
        }
        else if (_gamePlayTime <= 30.0f)
        {
            return 3; // 20~30�� ������ ���� ������ 3 (3��° ���͸�)
        }
        else
        {
            return 4; // 30�� ������ ���� ������ 4 (4��° ���͸�)
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
                GameObject monster = GameManager.Instance.Pool.Get(3); // 4��° ���ʹ� 3�� �ε����� �ش�
                monster.transform.position = _spawnPoint[spawnIndex].position;
                _spawnedFourthMonster = true;
            }
        }
    }

    private float GetSpawnInterval(float gameTime)
    {
        if (gameTime <= 10.0f)
        {
            return 1.0f; // 1~10�� ������ ���� ������ 0.2��
        }
        else
        {
            // 10�� ������ ���� ������ �����Ϸ��� �� ���� �����ϸ� �˴ϴ�.
            return 0.2f; // 10�� ���ĺ��ʹ� 1�ʿ� �� ���� ����
        }
    }
}    

