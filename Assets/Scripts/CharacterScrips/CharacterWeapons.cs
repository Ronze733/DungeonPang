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

    // Start is called before the first frame update
    private void Start()
    {
        _weapons[0] = GameObject.FindGameObjectWithTag("BasicWeapon");
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
