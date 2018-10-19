using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public enum EnemyStates
{

    IDIE,
    FINDWAY,
    ATTACK,
    ESCAPE,
    DIE,

}


public class FSM_AI : MonoBehaviour {
    public EnemyStates states = EnemyStates.IDIE;
    public NavMeshAgent Agent;
    public Transform EnemySelf;
    public Animator Anim;
    private Collider[] playerDetector;
    public GameObject[] Target;
    public Transform[] moveSpots;
    private int currentHealthy;
    private Collider[] attackDetector;
    public LayerMask attacklayerMask;
    bool escapebool;
    private float currentHealth = 0;
    private float enemyDamage = 5f;
    private Image healthbar2;
    bool attackbool = false;
    


    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();

        Anim = GetComponent<Animator>();

        EnemySelf = this.transform;

        //currentHealth = ;

    }

    void Update()
    {
        currentHealthy = gameObject.GetComponent<RedDumb>().currentHealth;
        playerDetector = gameObject.GetComponent<RedDumb>().playerDetector;
        healthbar2 = gameObject.GetComponent<RedDumb>().healthBar;
        EnemyChange(states);
        attackDetector = Physics.OverlapSphere(Agent.transform.position, 1, attacklayerMask);
        if(attackDetector.Length > 0)
        {
            states = EnemyStates.ATTACK;
        }
        if (states == EnemyStates.ESCAPE)
        {
            escapebool = true;
        }
        //if(states == EnemyStates.ATTACK)
        //{
        //    attackbool = false;
        //}
        if (currentHealthy <= 0)
        {
            states = EnemyStates.DIE;
        }

        //print(EnemyStates);
    }

    IEnumerator waitTwos()
    {
        yield return new WaitForSeconds(2);
        Agent.speed = 5.0f;
        attackbool = false;
        states = EnemyStates.FINDWAY;
    }

    public void TakeDamage()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().currentHealth = GameObject.FindWithTag("Player").GetComponent<Player>().currentHealth - enemyDamage;
    }


    private void EnemyChange(EnemyStates st)
    {

        switch (st)
        {
            case EnemyStates.IDIE:
                EnemyIdle();
                break;
            case EnemyStates.FINDWAY:
                FindWay();
                break;
            case EnemyStates.ATTACK:
                Attack();
                break;
            case EnemyStates.ESCAPE:
                Escape();
                break;
            case EnemyStates.DIE:
                Die();
                break;
            default:
                break;
        }
    }

    void EnemyIdle()
    {
        StartCoroutine(waitTwos());
        CancelInvoke();
    }

    void FindWay()
    {
        //float NextDistance = 1.5f;
        if (playerDetector.Length <= 0)
        {
            int x, y, z;
            x = Random.Range(-70, 50);
            y = Random.Range(-70, 50);
            z = Random.Range(-70, 50);
            Agent.SetDestination(new Vector3(x, y, z));
        }
        if (currentHealthy < 20 && escapebool == false)
        {
            states = EnemyStates.ESCAPE;
        }
        CancelInvoke();
    }
    void Attack()
    {
        if (attackbool == false)
        {
            InvokeRepeating("TakeDamage", 0.0f, 1.0f);
            attackbool = true;
        }
        if (attackDetector.Length > 0)
            states = EnemyStates.IDIE;
    }


    void Escape()
    {
        Agent.SetDestination(new Vector3(-30, 0, -20));
        Agent.speed = 30.0f;
        if(Agent.hasPath == false)
        {
            print("RUNNNNNNNNN");
            states = EnemyStates.IDIE;
        }
        CancelInvoke();
    }
    public void Die()
    {
       this.transform.localScale = new Vector3(1.0f, 0.2f, 1.0f);
        Destroy(this.gameObject, 2);
        Agent.speed =0.0f;
        Destroy(healthbar2);
        CancelInvoke();
    }
}