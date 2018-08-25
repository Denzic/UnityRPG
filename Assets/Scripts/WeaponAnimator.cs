using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimator : Interactable
{
    public Animator animator;


    // Update is called once per frame
    void Update ()
    {
        if (Agent.remainingDistance >= 1.9f && Agent.remainingDistance <= 2.5f)
            PerformAttack();
        else if (Agent.remainingDistance < 1.9f)
            StopAttack();
        //animator = gameObject.GetComponent<Animator>();
    }

    void PerformAttack()
    {
        animator.SetTrigger("normal_Attack"); ;
    }
    void StopAttack()
    {
        animator.SetTrigger("stop_Attack");
    }



}
