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

    private static bool _isDead = false; // 정적 변수로 변경

    private void Start()
    {
        _heathPoint = GetComponent<HealthPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDead) return;

        if (_heathPoint.HP == 0 && !_isDead)
        {
            Dead();
            _isDead = true;
            StartCoroutine(DestroyAfterDelay(2f)); // 2초 뒤에 사라지도록 설정
            return;
        }

        _dir = _player.transform.position - transform.position;
        if (_player != null)
        {
            if (_dir.magnitude < _attackRange)
                GetComponent<Animator>().SetBool("CanAttack", true);
            else
                GetComponent<Animator>().SetBool("CanAttack", false);
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

        GetComponent<Animator>().SetFloat("Speed", speed);
    }

    private void Dead()
    {
        GetComponent<Animator>().SetTrigger("Dead");
    }

    private void Turn(int direction)
    {
        var scale = transform.localScale;
        scale.x = Mathf.Sign(direction) * Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}