using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : NPC {

    

    public int TakeDamage(int amount, int currentHealth)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }

        return currentHealth;
    }

    public void Freeze()
    {

    }



    public void Die()
    {
        gameObject.GetComponent<FSM_AI>().Die();
    }


}
