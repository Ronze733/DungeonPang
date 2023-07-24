using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : WeaponSetting
{
    [SerializeField]
    private GameObject _boomerangProjectile;


    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (_characterOut.GetComponent<HealthPoint>().HP == 0) return;
    }
}
