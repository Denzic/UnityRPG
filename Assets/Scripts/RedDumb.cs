using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEditor;



public class RedDumb : Enemy {

    public int currentHealth = 0, toughness = 0;
    public int maxHealth = 50;
    public NavMeshAgent eneAgent;
    private Collider[] playerDetector;
    public LayerMask playerLayerMask;
    public Image healthBar;
    float burnTimer = 0;
    float normalized = 1;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        playerDetector = Physics.OverlapSphere(eneAgent.transform.position, 6, playerLayerMask);
        if (playerDetector.Length > 0)
        {
            print(playerDetector.Length);
            chasePlayer();
        }

        burnTimer += Time.deltaTime;
        if (burnTimer >= 3)
            ResetEnemyStatus();
        DisplayHealth();
        print(currentHealth);
    }

    public void chasePlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        eneAgent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LongSword")
            Die();

        if (other.tag == "Fireball")
        {
            currentHealth = TakeDamage((int)WeaponDamage.WeaponType.fireBall, currentHealth);
            InvokeRepeating("Burn", 0.5f, 0.5f);
            CalculateHealth(maxHealth, currentHealth);
            BurningEffect();
            burnTimer = 0f;
        }

        if (other.tag == "IceBall")
        {
            Freeze();
        }
    }

    void Burn()
    {
        currentHealth -= 5;
        CalculateHealth(maxHealth, currentHealth);
        if (currentHealth <= 0)
            Die();
    }

    private void CalculateHealth(int maxhealth, int currentHealth)
    {
        float clamped = Mathf.Clamp(currentHealth, 0f, maxhealth);
        normalized = (clamped - 0) / (maxHealth - 0);
    }

    private void DisplayHealth()
    {
        healthBar.fillAmount = normalized;
        if (normalized < 0.3f)
            healthBar.color = Color.red;
        if (normalized >= 0.3f)
            healthBar.color = Color.green;
    }

    void BurningEffect(){
        Renderer rend = GetComponent<Renderer>();
        rend.material.mainTexture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Textures/fire_tex.png", typeof(Texture2D));
        rend.material.shader = Shader.Find("Custom/FireBallShader");
    }

    void ResetEnemyStatus()
    {
        Renderer rend = GetComponent<Renderer>();
        CancelInvoke();
        rend.material.mainTexture = null;
        rend.material.shader = Shader.Find("Standard");
    }
}
