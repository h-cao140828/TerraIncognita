using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dragon : Enemy
{
    public PlayerStats playerStats;

    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "ZoneOneEasy")
        {
            healthLevel = 12;
            base.Start();
        }
        else
        {
            healthLevel = 20;
            base.Start();
        }
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
            playerStats.AwardedSP(50);
        }
        else
        {
            AudioManager.instance.Play("DragonHurt");
            animator.SetTrigger("Damage");
        }
    }
}
