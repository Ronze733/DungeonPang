using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour
{
    private Animator _animator;
    private Transform _monsterTransform;
    private TrollMonster _monster;
    public float _attackRange = 3f;
    private float _originalSpeed;
    private CircleCollider2D _circleCollider;
    // private bool _isAttack = false;
    /*
    public bool IsAttack
    {
        get { return _isAttack; }
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _monster = _animator.GetComponent<TrollMonster>();
        _circleCollider = _monster.GetComponentInChildren<CircleCollider2D>();
        _monsterTransform = _monster.transform;

        _originalSpeed = _monster._speed;
        _monster._speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (_monster != null && _monster._player != null)
            if (Vector2.Distance(_monsterTransform.position, _monster._player.position) <= _attackRange)
            {
                _animator.SetBool("IsFollow", true);
                _animator.SetBool("CanAttack", true);
                _monster._speed = 0f;
                _isAttack = true;
            }
            else
            {
                _animator.SetBool("CanAttack", false);
                _monster._speed = _originalSpeed;
                _isAttack = false;
                
            }
        }
        else
        {
            _animator.SetBool("CanAttack", false);
            _isAttack = false;
        }
        */
    }
}
