using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MonoBehaviour
{
    private Animator _animator;
    private Transform _monsterTransform;
    private TrollMonster _monster;

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
        if (Vector2.Distance(_monsterTransform.position, _monster._player.position) >= 0)
            _animator.SetBool("IsFollow", true);
    }
}
