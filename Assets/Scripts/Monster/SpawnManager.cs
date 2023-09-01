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

    private bool _spawnedFourthMonster;

    private void Awake()
    {
        _spawnPoint = GetComponentsInChildren<Transform>();
    }

    private void Start()
    {
        float gameTime = GameManager.Instance.GameTime;
        _spawnedFourthMonster = false;
    }

    private void Update()
    {
        Vector3 pos = _character.transform.position;
        this.transform.position = pos;

        _timer += Time.deltaTime;
        // GameManager.Instance.GameTime�� �̿��Ͽ� ���� �ð��� ����
        float gameTime = GameManager.Instance.GameTime;

        if (gameTime >= 30.0f && gameTime % 30.0f <= Time.deltaTime)
        {
            int spawnCount = 80; // ���ÿ� ������ ���� ����
            for (int i = 0; i < spawnCount; i++)
            {
                Spawn();
            }
        }

        float spawnInterval = GetSpawnInterval(gameTime);

        if (_timer > spawnInterval)
        {
            Spawn();
            _timer = 0;
        }
    }

    private int GetMonsterSpawnRange()
    {
        float gameTime = GameManager.Instance.GameTime;

        if (gameTime <= 60.0f)
        {
            return 1; 
        }
        else if (gameTime <= 120.0f)
        {
            return 2; 
        }
        else if (gameTime <= 240.0f)
        {
            return 3;
        }
        else if (gameTime <= 360.0f)
        {
            return 4;
        }
        else if (gameTime <= 480.0f)
        {
            return 5;
        }
        else
        {
            return 5;
        }
    }

    private void Spawn()
    {

        float gameTime = GameManager.Instance.GameTime;


        if (gameTime <= 600.0f)
        {
            int monsterSpawnRange = GetMonsterSpawnRange();
            GameObject monster = GameManager.Instance.Pool.Get(monsterSpawnRange - 1);
            monster.transform.position = _spawnPoint[UnityEngine.Random.Range(1, _spawnPoint.Length)].position;
        }
       
    }

    private float GetSpawnInterval(float gameTime)
    {
        if (gameTime <= 60.0f)
    {
        return 2.0f; // 0�к��� 1�б����� 3�� ����
    }
    else if (gameTime <= 240.0f)
    {
        return 1.0f; // 1�к��� 3�б����� 2�� ����
    }
    else if (gameTime <= 360.0f)
    {
        return 0.5f; // 3�к��� 5�б����� 1�� ����
    }
    else
    {
        return 0.1f; // 5�� ���ĺ��ʹ� 0.1�� ����
    }
    }
}    

