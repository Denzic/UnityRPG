using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour {

    private float maxHealth = 300f;
    public float currentHealth;
    public float normalized;
    private Image healthBar;
    public float enemyDamage = 5;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        healthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        DisplayHealth();
        CalculateHealth(maxHealth, currentHealth);

    }



    private void CalculateHealth(float maxhealth, float currentHealth)
    {
        float clamped = Mathf.Clamp(currentHealth, 0f, maxhealth);
        normalized = (clamped - 0) / (maxhealth - 0);
        print(currentHealth);
    }

    private void DisplayHealth()
    {
        healthBar.fillAmount = normalized;
        if (normalized < 0.3f)
            healthBar.color = Color.red;
        if (normalized >= 0.3f)
            healthBar.color = Color.green;
    }
}
