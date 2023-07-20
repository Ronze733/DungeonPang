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

    private void Start()
    {
        _coolTerm = 1.0f;
        _thunderProjectile.GetComponent<ThunderProjectile>().Damage = 5f;
    }


    // Update is called once per frame
    private void Update()
    {
        LevelCheck(_weaponLevel);

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
            float x = Random.Range(-10.0f, 10.0f);
            float y = Random.Range(-10.0f, 10.0f);
            dir.x = x;
            dir.y = y;

            Destroy(Instantiate(_thunderProjectile, pos + dir, Quaternion.identity), _aliveTime);
        }
    }

    

    private void LevelCheck(int weaponLevel)
    {
        
    }

}
