using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkill : MonoBehaviour
{
    private GameObject[] _monsters = null;

    [SerializeField]
    private ParticleSystem _particle = null;

    [SerializeField]
    private float _QCoolTerm = 20.0f;
    private float _QCoolTime = 0f;

    [SerializeField]
    private float _WCoolTerm = 60.0f;
    private float _WCoolTime = 0f;

    [SerializeField]
    private float _ECoolTerm = 30.0f;
    private float _ECoolTime = 0f;

    private void Update()
    {
        _monsters = GameObject.FindGameObjectsWithTag("Monster");

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (_QCoolTime == 0)
            {
                foreach (GameObject monster in _monsters)
                {
                    monster.GetComponent<HealthPoint>().HP = 0;
                    if (_particle != null)
                        _particle.Play();
                }
                _QCoolTime += Time.deltaTime;
            }
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            if(_WCoolTime == 0)
            {
                this.gameObject.GetComponent<HealthPoint>().HP = Mathf.Clamp(this.gameObject.GetComponent<HealthPoint>().MaxHP * 0.5f + this.gameObject.GetComponent<HealthPoint>().HP, 0, this.gameObject.GetComponent<HealthPoint>().MaxHP); 
                _WCoolTime += Time.deltaTime;
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            // TODO 스피드 증가 함수 제작
        }




        if(_QCoolTime != 0)
            _QCoolTime += Time.deltaTime;

        if (_QCoolTime >= _QCoolTerm)
            _QCoolTime = 0f;

        if(_WCoolTime != 0)
            _WCoolTime += Time.deltaTime;

        if (_WCoolTime >= _WCoolTerm)
            _WCoolTime = 0f;

        if(_ECoolTime != 0)
            _ECoolTime += Time.deltaTime;

        if (_ECoolTime >= _ECoolTerm)
            _ECoolTime = 0f;


    }
}
