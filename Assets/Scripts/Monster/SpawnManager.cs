using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform[] _spawnPoint;

    float _timer;

    void Awake()
    {
        _spawnPoint = GetComponentsInChildren<Transform>();
          
    }
        void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 0.2f)
        {
            Spawn();
            _timer = 0;
        }
    }

    void Spawn()
    {
        GameObject monster = GameManager._instance._pool.Get(Random.Range(0,1));
        monster.transform.position = _spawnPoint[Random.Range(1,_spawnPoint.Length)].position ;

    }
}    

