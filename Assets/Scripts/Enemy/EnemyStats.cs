using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int maxHealth;
    public int currentHealth;

    Animator animator;

    // Start is called before the first frame update
    public void Start()
    {
        animator = GetComponent<Animator>();
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
    }

    int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            animator.SetTrigger("Death");
            // handle death
            GetComponent<NavMeshAgent>().enabled = false;
        }
        else
        {
            animator.SetTrigger("Damage");
        }

    }

    //public void TakeDamage(int damage)
    //{
    //    currentHealth -= damage;

    //    animator.SetTrigger("Damage");

    //    if (currentHealth <= 0)
    //    {
    //        currentHealth = 0;
    //        animator.SetBool("IsDead", true);
    //        // handle death
    //        GetComponent<EnemyController>().enabled = false;
    //    }

    //}
}
