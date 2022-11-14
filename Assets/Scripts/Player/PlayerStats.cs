using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

    public Canvas playerUI;
    public HealthBar healthBar;

    PlayerCombat playerCombat;
    Animator animator;

    public int healthLevel = 10;
    public int strengthLevel = 10;
    public int defenseLevel = 10;

    public int spCount = 0;

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
            playerUI.gameObject.transform.Find("Vitality Bar").gameObject.SetActive(true);
        else
            playerUI.gameObject.transform.Find("Vitality Bar").gameObject.SetActive(false);
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
        currentHealth -= (damage - Mathf.RoundToInt(damage * blockReduction));
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
