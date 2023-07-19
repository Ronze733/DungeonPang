using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    [SerializeField]
    private float _maxHealthPoint;
    public float MaxHP
    { 
        get { return _maxHealthPoint; }
    }
    [SerializeField]
    private float _healthPoint;

    [SerializeField]
    private GameObject _character;

    public float HP
    {
        get { return _healthPoint; }
        set { _healthPoint = value; }
    }

    private void Start()
    {
        _healthPoint = _maxHealthPoint;
    }

    public void Hit(float damage)
    {
        _character.GetComponent<Animator>().SetTrigger("Hit");
        _healthPoint = Mathf.Clamp(_healthPoint - damage, 0, _maxHealthPoint);
    }
}
