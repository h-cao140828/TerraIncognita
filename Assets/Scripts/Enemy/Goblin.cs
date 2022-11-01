using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    private void Awake()
    {
        healthLevel = 10;
        base.Start();
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
        }
        else
        {
            AudioManager.instance.Play("GoblinHurt");
            animator.SetTrigger("Damage");
        }
    }
}
