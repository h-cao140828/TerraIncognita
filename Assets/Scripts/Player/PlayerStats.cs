using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int maxHealth;
    public int currentHealth;

    public Canvas combatUI;
    public HealthBar healthBar;

    PlayerCombat playerCombat;
    Animator animator;

    // Amount of damage the player can block
    public float blockReduction = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        playerCombat = GetComponent<PlayerCombat>();
        animator = GetComponent<Animator>();
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (!playerCombat.sheathed)
            combatUI.gameObject.SetActive(true);
        else
            combatUI.gameObject.SetActive(false);
    }

    int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetCurrentHealth(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            animator.SetTrigger("Death");
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
        }
        else
        {
            animator.SetTrigger("Damage");
        }
    }
}
