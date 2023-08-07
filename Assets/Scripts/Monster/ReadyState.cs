using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyState : MonoBehaviour
{
    private Animator _animator;
    private Transform _monsterTransform;
    private TrollMonster _monster;
    public float _attackRange = 1f;
    public float _speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _monster = _animator.GetComponent<TrollMonster>();
        _monsterTransform = _animator.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
      
        
    }
}
