using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollMonster : MonoBehaviour
{
    public Transform _player;
    private Transform _monsterTransform;
    private Transform _monster;

    private Animator _animator;

    private HealthPoint _heathPoint;

    [SerializeField]
    private GameObject _coin;

    [SerializeField]
    private float _coinDropProbability = 80f;

    [SerializeField]
    private GameObject _exp;


    [SerializeField]
    private float _attackRange = 3f;

    public float _speed = 5f;
    private Vector2 _dir;

    private bool _isDead = false;

    private void Start()
    {
        _heathPoint = this.GetComponent<HealthPoint>();
        _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("RealPlayer").transform;
        _monster = this.transform;
        _monsterTransform = _monster.transform;
        StartCoroutine(ChangeSpeedAfterDelay(10f));
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isDead) return;

        if (_heathPoint.HP == 0 && !_isDead)
        {
            Dead();
            _isDead = true;
            StartCoroutine(DestroyAfterDelay(2f));
            if (Random.Range(0f, 100f) < _coinDropProbability)
            {
                Instantiate(_coin, transform.position, Quaternion.identity);
            }
            Instantiate(_exp, transform.position, Quaternion.identity);
            return;
        }

        _dir = _player.transform.position - this.transform.position;
        
        if (_dir.x < 0)
            Turn(-1);
        else if (_dir.x > 0)
            Turn(1);

        float speed;
        speed = _speed;
        transform.Translate(_dir.normalized * speed * Time.deltaTime);

        if (_monster != null && _player != null)
        {
            _animator.SetBool("IsFollow", true);
            _animator.SetFloat("Speed", speed);
        }
        else
        {
            _animator.SetBool("IsFollow", false);
            _animator.SetFloat("Speed", speed);
        }

        // Debug.Log(Vector2.Distance(_monster.position, _player.position));

        float l = Vector2.Distance(_monster.position, _player.position);
        Debug.Log(l);
        if (l <= _attackRange)
        {
            Debug.Log(1);
            _animator.SetBool("CanAttack", true);
        }
        else
        {
            Debug.Log(2);
            _animator.SetBool("CanAttack", false);
        }
       
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

    private IEnumerator ChangeSpeedAfterDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            _speed = 15f;
            yield return new WaitForSeconds(3f); // 3초 대기
            _speed = 5f; // 다시 스피드를 3으로 변경
        }
    }
}
