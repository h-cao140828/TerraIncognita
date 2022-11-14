using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemy
{
    public PlayerStats playerStats;

    private void Awake()
    {
        healthLevel = 20;
        base.Start();
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            AudioManager.instance.Play("DragonDeath");
            animator.SetTrigger("Death");
            GetComponent<Collider>().enabled = false;
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            playerStats.AwardedSP(100);
        }
        else
        {
            AudioManager.instance.Play("DragonHurt");
            animator.SetTrigger("Damage");
        }
    }
}
