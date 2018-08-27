using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimator : Interactable
{
    public Animator animator;
    private Collider[] enemyDetector;
    public LayerMask enemyLayerMask;

    // Update is called once per frame
    void Update ()
    {
        //animator = gameObject.GetComponent<Animator>();

        EnemyCheck();
    }
    public void EnemyCheck()
    {
        enemyDetector = Physics.OverlapSphere(Agent.transform.position, 3, enemyLayerMask);
        if (enemyDetector.Length > 0 )
        {
            //print(enemyDetector.Length);
            if (Agent.remainingDistance >= 1.9f && Agent.remainingDistance <= 2.5f)
                PerformAttack();
            if (Agent.remainingDistance < 1.9f)
                StopAttack();
        }
        if (enemyDetector.Length == 0)
            StopAttack();
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
