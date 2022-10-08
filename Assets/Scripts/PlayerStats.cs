using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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

        animator.SetTrigger("Damage");

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            animator.SetBool("IsDead", true);
            // Set int 0 for normal death, int 1 for dramatic, int greater than 1 for kek
            animator.SetInteger("DamageTaken", 0);
            // Handle player death
        }
    }
}
