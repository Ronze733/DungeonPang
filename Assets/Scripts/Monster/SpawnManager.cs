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

    private void Awake()
    {
        _spawnPoint = GetComponentsInChildren<Transform>();
    }

    private void Start()
    {
        _gamePlayTime = 0.0f;
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

    private void Spawn()
    {
        GameObject monster = GameManager.Instance.Pool.Get(Random.Range(0, GetMonsterSpawnRange()));
        monster.transform.position = _spawnPoint[Random.Range(1, _spawnPoint.Length)].position;
    }

    private int GetMonsterSpawnRange()
    {
        if (_gamePlayTime <= 10.0f)
        {
            return 1; // 1~10�� ������ Range(0, 0) ��ȯ
        }
        else
        {
            return 2; // 10�� ���ĺ��ʹ� Range(0, 1) ��ȯ
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

