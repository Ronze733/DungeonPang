using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollAttack : MonoBehaviour
{
    [SerializeField]
    public GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            float dmg = this.GetComponentInParent<Damage>().DamageValue;
            _player.GetComponent<HealthPoint>().Hit(dmg);
        }

    }


}
