using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
    public Transform[] _spawnPoint;
    public GameObject _monsterPrefab;
    public GameObject _character; // Serialize this field in the Inspector

    private bool _hasSpawned = false;

    private void Awake()
    {
        _spawnPoint = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        Vector3 pos = _character.transform.position;
        transform.position = pos;

        if (!_hasSpawned)
        {
            SpawnMonster(3);
            _hasSpawned = true;
        }
    }

    private void SpawnMonster(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(1, _spawnPoint.Length);
            Transform spawnTransform = _spawnPoint[randomIndex];

            Instantiate(_monsterPrefab, spawnTransform.position, spawnTransform.rotation);
        }
    }
}
