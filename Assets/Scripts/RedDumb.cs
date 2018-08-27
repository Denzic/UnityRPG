using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RedDumb : Enemy {

    public float currentHealth, power, toughness;
    public float maxhealth;
    public NavMeshAgent eneAgent;
    private Collider[] playerDetector;
    public LayerMask playerLayerMask;


    private void Start()
    {
        currentHealth = maxhealth;
    }

    private void Update()
    {
        playerDetector = Physics.OverlapSphere(eneAgent.transform.position, 6, playerLayerMask);
        if (playerDetector.Length > 0)
        {
            print(playerDetector.Length);
            chasePlayer();
        }
        //chasePlayer();

    }

    public void chasePlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        eneAgent.SetDestination(player.transform.position);
    }
    public void PerformAttack()
    {
        
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
