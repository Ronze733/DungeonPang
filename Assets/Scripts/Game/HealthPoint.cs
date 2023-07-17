using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    [SerializeField]
    private float _maxHealthPoint;
    [SerializeField]
    private float _healthPoint;

    [SerializeField]
    private GameObject _character;

    public float HP
    {
        get { return _healthPoint; }
        set { _healthPoint = value; }
    }

    [SerializeField]
    private float _damageTime;

    private void Start()
    {
        _healthPoint = _maxHealthPoint;
    }

    public void Hit(float damage, float damageTime)
    {
        if(damageTime > _damageTime)
        {
            _character.GetComponent<Animator>().SetTrigger("Hit");
            _healthPoint = Mathf.Clamp(_healthPoint - damage, 0, _maxHealthPoint);
        }
    }
}
