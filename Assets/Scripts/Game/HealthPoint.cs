using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    [SerializeField]
    private float _maxHealthPoint;
    private float _healthPoint;

    [SerializeField]
    private float _damageTime;

    private void Start()
    {
        _healthPoint = _maxHealthPoint;
    }

    private void Hit(float damage, float damageTime)
    {
        if(damageTime > _damageTime)
        {
            this.GetComponent<Animator>().SetTrigger("Hit");
            _healthPoint = Mathf.Clamp(_healthPoint - damage, 0, _maxHealthPoint);
        }
    }
}
