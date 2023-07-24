using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : WeaponSetting
{
    [SerializeField]
    private GameObject _StarProjectile;


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
