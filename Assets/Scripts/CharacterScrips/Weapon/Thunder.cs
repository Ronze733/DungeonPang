using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : WeaponSetting
{
    [SerializeField]
    private GameObject _thunderProjectile = null;

    [SerializeField]
    private float _coolTerm = 1.0f;
    private float _coolTime = 0f;

    private float _aliveTime = 0.5f;

    private int _beforeLevel = 1;

    private bool _beforeCan = false;

    private void Start()
    {
        _coolTerm = 1.0f;
        _thunderProjectile.GetComponent<ThunderProjectile>().Damage = 5f;
        _beforeLevel = _weaponLevel;
        _beforeCan = _canWeapon;
    }


    // Update is called once per frame
    private void Update()
    {
        if(_beforeLevel != _weaponLevel)
            LevelCheck(_weaponLevel);

        if(_canWeapon && !_beforeCan)
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterWeapons>()._weaponsLength < 6)
            {
                int len = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterWeapons>()._weaponsLength;
                GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterWeapons>().Weapons[len] = this.gameObject;
                _beforeCan = _canWeapon;
            }

        if (_canWeapon)
        {     
            if (_coolTime > _coolTerm)
            {
                AttackTunder(_weaponLevel);
                _coolTime = 0f;
            }
            _coolTime += Time.deltaTime;
        }
    }

    private void AttackTunder(int weaponLevel)
    {
        int thunderNum = 1;
        switch (weaponLevel)
        {
            case 1:
                thunderNum = 1;
                break;
            case 2:
                thunderNum = 2;
                break;
            case 3:
            case 4:
                thunderNum = 4;
                break;
            case 5:
            case 6:
                thunderNum = 8;
                break;
        }

        for(int i = 0; i < thunderNum; i++)
        {
            Vector3 pos = _character.transform.position;

            Vector3 dir = Vector3.zero;
            float x = Random.Range(-8.0f, 8.0f);
            float y = Random.Range(-8.0f, 8.0f);
            dir.x = x;
            dir.y = y;

            Destroy(Instantiate(_thunderProjectile, pos + dir, Quaternion.identity), _aliveTime);
        }
    }

    

    private void LevelCheck(int weaponLevel)
    {
        switch (weaponLevel)
        {
            case 1:
                _coolTerm *= 0.9f;
                _thunderProjectile.GetComponent<ThunderProjectile>().Damage += 3;
                break;
            case 2:
                _coolTerm *= 0.9f;
                _thunderProjectile.GetComponent<ThunderProjectile>().Damage += 3;
                break;
            case 3:
                _coolTerm *= 0.9f;
                _thunderProjectile.GetComponent<ThunderProjectile>().Damage += 3;
                break;
            case 4:
                _coolTerm *= 0.9f;
                _thunderProjectile.GetComponent<ThunderProjectile>().Damage += 3;
                break;
            case 5:
                _coolTerm *= 0.9f;
                _thunderProjectile.GetComponent<ThunderProjectile>().Damage += 3;
                break;
            case 6:
                _coolTerm *= 0.9f;
                _thunderProjectile.GetComponent<ThunderProjectile>().Damage += 3;
                break;
        }
        _beforeLevel = _weaponLevel;
    }

}
