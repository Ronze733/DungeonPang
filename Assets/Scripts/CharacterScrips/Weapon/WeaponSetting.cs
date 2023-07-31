using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponSetting : MonoBehaviour
{
    [SerializeField]
    protected bool _canWeapon = false;
    public bool CanWeapon
    {
        get { return _canWeapon; }
        set { _canWeapon = value; }
    }

    protected GameObject _character = null;

    [SerializeField]
    [Range(1f, 6f)]
    protected int _weaponLevel = 1;

    public int WeaponLevel
    {
        get { return _weaponLevel; }
        set { _weaponLevel = value; }
    }

    protected GameObject _characterOut;

    protected void Awake()
    {
        _character = GameObject.FindGameObjectWithTag("RealPlayer");
        _canWeapon = false;
        _weaponLevel = 1;
        _characterOut = GameObject.FindGameObjectWithTag("Player");
    }
}
