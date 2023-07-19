using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

 
    private HealthPoint _heathPoint;


    [SerializeField]
    private float _attackRange = 1f;

    public float _speed;
    private Vector2 _dir;

    private bool _isDead = false;

    private void Start()
    {
       _heathPoint = this.GetComponent<HealthPoint>();
        _player = GameObject.FindGameObjectWithTag("RealPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        if(_isDead) return;

        if (_heathPoint.HP == 0 && !_isDead)
        {
            Dead();
            _isDead = true;
            StartCoroutine(DestroyAfterDelay(2f));
            return;
        }

        _dir = _player.transform.position - this.transform.position;
        if (_player != null)
        {
            if (_dir.magnitude < _attackRange)
                this.gameObject.GetComponent<Animator>().SetBool("CanAttack", true);
            else
                this.gameObject.GetComponent<Animator>().SetBool("CanAttack", false);
        }

        if (_dir.x < 0)
            Turn(-1);
        else if (_dir.x > 0)
            Turn(1);

        float speed;
        if (_dir.magnitude <= _attackRange)
            speed = 0;
        else
            speed = _speed;

        transform.Translate(_dir.normalized * speed * Time.deltaTime);

        this.gameObject.GetComponent<Animator>().SetFloat("Speed", speed);

        


    }

    private void Dead()
    {
        this.gameObject.GetComponent<Animator>().SetTrigger("Dead");
    }

    private void Turn(int direction)
    {
        var scale = this.gameObject.transform.localScale;

        scale.x = Mathf.Sign(direction) * Mathf.Abs(scale.x);

        gameObject.transform.localScale = scale;

    }
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
