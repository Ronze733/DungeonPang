using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private float damage;

    public float DamageValue
    {
        get { return damage; }
        set { damage = value; }
    }
}
