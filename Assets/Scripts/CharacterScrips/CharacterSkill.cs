using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkill : MonoBehaviour
{
    private GameObject[] _monsters = null;

    [SerializeField]
    private ParticleSystem _particle = null;

    private void Update()
    {
        _monsters = GameObject.FindGameObjectsWithTag("Monster");

        if(Input.GetKeyDown(KeyCode.Q))
        {
            foreach(GameObject monster in _monsters)
            {
                monster.GetComponent<HealthPoint>().HP = 0;
                if(_particle != null)
                    _particle.Play();
            }
        }
    }
}
