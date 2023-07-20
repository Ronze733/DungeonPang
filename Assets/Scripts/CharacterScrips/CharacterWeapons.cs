using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapons : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _weapons = new GameObject[6];
    public GameObject[] Weapons
    {
        get { return _weapons; }
        set { _weapons = value; }
    }

    public int _weaponsLength = 1;

    // Start is called before the first frame update
    private void Start()
    {
        _weapons = new GameObject[6];
        _weapons[0] = GameObject.FindGameObjectWithTag("BasicWeapon");
        _weaponsLength = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        for(int i = 0; i < _weapons.Length; i++)
        {
            if (_weapons[i] == null)
            {
                _weaponsLength = i;
                break;
            }
        }
    }
}
