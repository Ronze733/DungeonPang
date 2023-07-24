using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField]
    private float _exp = 0;
    public float Exp
    { get { return _exp; } }
    [SerializeField]
    private float _maxExp = 10;
    public float MaxExp
    { get { return _maxExp; } }

    private int _level = 1;

    private HealthPoint _healthPoint = null;

    private void Awake()
    {
        _healthPoint = this.GetComponent<HealthPoint>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _exp = 0;
        _maxExp = 10;
        _level = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if(_exp >= _maxExp)
        {
            _exp -= _maxExp;
            _maxExp *= 1.5f;
            _level += 1;
            SelectWeapon();
            _healthPoint.MaxHP += 10;
            _healthPoint.HP += 10;
        }
    }

    private void SelectWeapon()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Exp")
        {
            float exp = collision.GetComponent<Exp>().Value;
            _exp += exp;

            Destroy(collision.gameObject);
        }
    }
}
