using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDumb : Enemy {

    public float currentHealth, power, toughness;
    public float maxhealth;

    private void Start()
    {
        currentHealth = maxhealth;
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
