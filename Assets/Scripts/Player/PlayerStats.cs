using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public int attackDamage = 20;
    public int defence = 5;

    public Canvas playerUI;
    public HealthBar healthBar;

    PlayerCombat playerCombat;
    Animator animator;

    public int playerLevel = 1;

    public int healthLevel = 1;
    public int strengthLevel = 1;
    public int defenseLevel = 1;
    //public int intelligenceLevel = 10;

    public int spCount = 0;

    // Amount of damage the player can block
    public float blockReduction = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        playerCombat = GetComponent<PlayerCombat>();
        animator = GetComponent<Animator>();
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        attackDamage = setAttackDamage();
        defence = setDefence();
    }

    private void Update()
    {
        if (!playerCombat.sheathed)
            playerUI.gameObject.transform.Find("Vitality Bar").gameObject.SetActive(true);
        else
            playerUI.gameObject.transform.Find("Vitality Bar").gameObject.SetActive(false);
    }

    public int SetMaxHealthFromHealthLevel()
    {
        maxHealth = maxHealth + (healthLevel * 25);
        return maxHealth;
    }

    public int setAttackDamage()
    {
        attackDamage = attackDamage + (strengthLevel * 5);
        return attackDamage;
    }

    public int setDefence()
    {
        defence = defence + (defenseLevel * 2);
        return defence;
    }


    public void TakeDamage(int damage)
    {
        damage -= defence;
        currentHealth -= damage;
        healthBar.SetCurrentHealth(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            AudioManager.instance.Play("PlayerDeath");
            animator.SetTrigger("Death");
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
        }
        else
        {
            AudioManager.instance.Play("PlayerHurt");
            animator.SetTrigger("Damage");
            if (playerCombat.sheathed)
                animator.SetBool("IsCombat", false);
            else
                animator.SetBool("IsCombat", true);
        }
    }

    public void TakeReducedDamage(int damage)
    {
        currentHealth -= (damage - Mathf.RoundToInt(damage * blockReduction) - defence);
        healthBar.SetCurrentHealth(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            AudioManager.instance.Play("PlayerDeath");
            animator.SetTrigger("Death");
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
        }
        else
        {
            AudioManager.instance.Play("ShieldBlock");
            animator.SetTrigger("Blocked");
        }
    }

    public void AwardedSP(int sp)
    {
        spCount += sp;
    }
}
