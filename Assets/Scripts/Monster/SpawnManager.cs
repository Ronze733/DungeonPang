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

    float _timer;

    private void Awake()
    {
        _spawnPoint = GetComponentsInChildren<Transform>();
          
    }
    private void Update()
    {
        Vector3 pos = _character.transform.position;
        this.transform.position = pos;

        _timer += Time.deltaTime;

        if (_timer > 0.2f)
        {
            Spawn();
            _timer = 0;
        }
    }

    private void Spawn()
    {
        GameObject monster = GameManager._instance._pool.Get(Random.Range(0,1));
        monster.transform.position = _spawnPoint[Random.Range(1,_spawnPoint.Length)].position ;

    }
}    

