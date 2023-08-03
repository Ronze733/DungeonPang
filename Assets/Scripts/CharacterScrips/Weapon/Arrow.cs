using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float _damage = 3f;
    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    [SerializeField]
    private float _speed = 5f;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    [SerializeField]
    private float _aliveTime;
    private float _time;

    // Update is called once per frame
    private void Update()
    {
        this.transform.Translate(Vector2.right * _speed * Time.deltaTime);

        if (_time > _aliveTime)
            Destroy(this.gameObject);

        _time += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Monster" || collision.gameObject.tag == "Boss")
        {
            HealthPoint monsterHP = collision.GetComponent<HealthPoint>();

            monsterHP.HP = Mathf.Clamp(monsterHP.HP - _damage, 0, monsterHP.HP);
        }
    }
}
