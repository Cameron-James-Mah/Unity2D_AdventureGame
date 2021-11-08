using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonReanimate : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int rnd = Random.Range(1, 5);
        if(rnd > 1)
        {
            Destroy(animator.gameObject, stateInfo.length);
        }
        else
        {
            animator.SetTrigger("isReanimating");
        }
       
    }
}
