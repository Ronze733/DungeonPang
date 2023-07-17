using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWalk : StateMachineBehaviour
{
    Transform mosterTransform;
    Monster monster;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.GetComponent<Monster>();
        mosterTransform = animator.GetComponent<Transform>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         //mosterTransform.position = Vector2.MoveTowards(mosterTransform.position, monster._player.position, Time.deltaTime * monster._speed);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
