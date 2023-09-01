using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : WeaponSetting
{
    [SerializeField]
    private GameObject _StarProjectile;

    [SerializeField]
    private float _setCoolTerm;
    private float _coolTerm;
    private float _coolTime = Mathf.Infinity;

    private float _aliveTime = 5f;

    private int _beforeLevel = 1;

    private bool _beforeCan = false;

    [SerializeField]
    private float _damage;


    private void Start()
    {
        _coolTerm = _setCoolTerm;
        _StarProjectile.GetComponent<StarProjectile>().Damage = _damage;
        _beforeLevel = _weaponLevel;
        _beforeCan = _canWeapon;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_characterOut.GetComponent<HealthPoint>().HP == 0) return;
        if (_beforeLevel != _weaponLevel)
            CheckLevel(_weaponLevel);

        if (_canWeapon && !_beforeCan)
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
                ShootStar(_weaponLevel);
                _coolTime = 0f;
            }
            _coolTime += Time.deltaTime;
        }
    }

    private void CheckLevel(int weaponLevel)
    {
        switch (weaponLevel)
        {
            case 1:
                _coolTerm *= 0.9f;
                _StarProjectile.GetComponent<StarProjectile>().Damage += 3;
                break;
            case 2:
                _coolTerm *= 0.9f;
                _StarProjectile.GetComponent<StarProjectile>().Damage += 3;
                break;
            case 3:
                _coolTerm *= 0.9f;
                _StarProjectile.GetComponent<StarProjectile>().Damage += 3;
                break;
            case 4:
                _coolTerm *= 0.9f;
                _StarProjectile.GetComponent<StarProjectile>().Damage += 3;
                break;
            case 5:
                _coolTerm *= 0.9f;
                _StarProjectile.GetComponent<StarProjectile>().Damage += 3;
                break;
            case 6:
                _coolTerm *= 0.9f;
                _StarProjectile.GetComponent<StarProjectile>().Damage += 3;
                break;
        }
        _beforeLevel = _weaponLevel;
    }

    private void ShootStar(int weaponLevel)
    {
        int StarNum = 1;
        switch (weaponLevel)
        {
            case 1:
                StarNum = 1;
                break;
            case 2:
                StarNum = 2;
                break;
            case 3:
                StarNum = 3;
                break;
            case 4:
                StarNum = 4;
                break;
            case 5:
                StarNum = 5;
                break;
            case 6:
                StarNum = 6;
                break;
        }

        for (int i = 0; i < StarNum; i++)
        {
            Vector3 pos = _character.transform.position;

            Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            Destroy(Instantiate(_StarProjectile, pos, randomRotation), _aliveTime);
        }
        AudioManager._instance.PlaySfx(AudioManager.Sfx.Lazer);
    }
}
