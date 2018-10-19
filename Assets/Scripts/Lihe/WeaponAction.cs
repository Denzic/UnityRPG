using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAction : Interactable
{
    public Animator animator;
    private Collider[] enemyDetector;
    public LayerMask enemyLayerMask;
    private FireBall fireball;
    private IceBall iceBall;
    public Transform projectileSpawn;

    private void Start()
    {
        fireball = Resources.Load<FireBall>("FireBall");
        iceBall = Resources.Load<IceBall>("IceBall");
    }
    // Update is called once per frame
    void Update ()
    {
        EnemyCheck();
    }
    public void EnemyCheck()
    {
        enemyDetector = Physics.OverlapSphere(Agent.transform.position + Agent.transform.forward, 2, enemyLayerMask);
        if (enemyDetector.Length > 0 )
        {
            //print(enemyDetector.Length);
            if (Agent.remainingDistance < 1.9f)
                StopAttack();
            if (Agent.remainingDistance >= 1.9f && Agent.remainingDistance <= 2.5f)
                PerformAttack();
        }
        if (enemyDetector.Length == 0)
            StopAttack();
    }

    public void PerformAttack()
    {
        animator.SetTrigger("normal_Attack");
    }
    //public void Setbool()
    //{
    //    animator.SetBool("normal_Attack", true);
    //}
    void StopAttack()
    {
        animator.SetTrigger("stop_Attack");
    }

    public void CastSpell()
    {
        FireBall fireballinstance = Instantiate(fireball, projectileSpawn.position, projectileSpawn.rotation);
        fireballinstance.Direction = projectileSpawn.forward;
    }

    public void CastIceBall()
    {
        IceBall iceballinstance = Instantiate(iceBall, projectileSpawn.position, projectileSpawn.rotation);
        iceballinstance.Direction = projectileSpawn.forward;
    }

}
