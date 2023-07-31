using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyState : StateMachineBehaviour
{
    private Transform _monsterTransform;
    private TrollMonster _monster;
    public float _attackRange = 1f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _monster = animator.GetComponent<TrollMonster>();
        _monsterTransform = animator.GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (Vector2.Distance(_monster._player.position, _monsterTransform.position) > 1f)
            animator.SetBool("IsFollow", true);

        if (Vector2.Distance(_monsterTransform.position, _monster._player.position) <= _attackRange)
            animator.SetTrigger("CanAttack");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
