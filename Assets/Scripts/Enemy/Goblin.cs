using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goblin : Enemy
{
    public PlayerStats playerStats;

    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "ZoneOneEasy") {
            healthLevel = 6;
            base.Start();
        }
        else
        {
            healthLevel = 10;
            base.Start();
        }

    }


    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            AudioManager.instance.Play("GoblinDeath");
            animator.SetTrigger("Death");
            GetComponent<Collider>().enabled = false;
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            playerStats.AwardedSP(25);
        }
        else
        {
            AudioManager.instance.Play("GoblinHurt");
            animator.SetTrigger("Damage");
        }
    }
}
