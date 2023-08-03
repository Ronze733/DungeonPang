using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField]
    private float _exp = 0;
    public float Exp
    { get { return _exp; } }

    private float _maxExp = 5;
    public float MaxExp
    { get { return _maxExp; } }

    private int _level = 1;

    private int _coin = 0;
    public int Coin
    { get { return _coin; } }

    private HealthPoint _healthPoint = null;

    private CharacterWeapons _characterWeapons = null;

    [SerializeField]
    private GameObject _levelUpManager = null;

    private void Awake()
    {
        _healthPoint = this.GetComponent<HealthPoint>();
        _characterWeapons = this.GetComponent<CharacterWeapons>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _exp = 0;
        _maxExp = 5;
        _level = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if(_exp >= _maxExp)
        {
            _exp -= _maxExp;
            _maxExp += 3f;
            _level += 1;
            _healthPoint.MaxHP += 10;
            _healthPoint.HP += 10;
            _levelUpManager.GetComponent<LevelupManager>().LevelUp();
        AudioManager._instance.PlaySfx(AudioManager.Sfx.Level);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Exp")
        {
            float exp = collision.GetComponent<Exp>().Value;
            _exp += exp;

            Destroy(collision.gameObject);
            AudioManager._instance.PlaySfx(AudioManager.Sfx.Exp);
        }

        if(collision.gameObject.tag == "Coin")
        {
            float coin = collision.GetComponent<Coin>().Value;
            _coin += (int)coin;

            Destroy(collision.gameObject);
            AudioManager._instance.PlaySfx(AudioManager.Sfx.Coin);
        }
    }
}
