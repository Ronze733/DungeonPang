using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/MakeNewWeapon", order = 0)]

public class Weapons : ScriptableObject
{
    [SerializeField]
    private string _weaponName;

    [SerializeField]
    private ParticleSystem _particleSystem;

    [SerializeField]
    private Image _image;

    [SerializeField]
    private float _damage;
    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
}
