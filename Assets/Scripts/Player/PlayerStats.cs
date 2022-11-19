using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public int attackDamage;
    public int defence;

    public Canvas playerUI;
    public HealthBar healthBar;

    PlayerCombat playerCombat;
    Animator animator;

    public int playerLevel = 1;

    public int healthLevel = 1;
    public int strengthLevel = 1;
    public int defenseLevel = 1;

    public int spCount = 0;

    // Amount of damage the player can block
    public float blockReduction = 0.3f;

    private void Awake()
    {
        spCount = PlayerPrefs.GetInt("SP", 0);
        playerLevel = PlayerPrefs.GetInt("Level", 1);
        healthLevel = PlayerPrefs.GetInt("Health", 1);
        strengthLevel = PlayerPrefs.GetInt("Strength", 1);
        defenseLevel = PlayerPrefs.GetInt("Defense", 1);
        PlayerPrefs.DeleteAll();
    }

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
        // Used to turn on and off player health bar
        //if (!playerCombat.sheathed)
        //    playerUI.gameObject.transform.Find("Vitality Bar").gameObject.SetActive(true);
        //else
        //    playerUI.gameObject.transform.Find("Vitality Bar").gameObject.SetActive(false);
    }

    public int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 75;
        return maxHealth;
    }

    public int setAttackDamage()
    {
        attackDamage = strengthLevel * 20;
        return attackDamage;
    }

    public int setDefence()
    {
        defence = defenseLevel * 2;
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
            StartCoroutine(timer());
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
            StartCoroutine(timer());
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

    public void Respawn()
    {
        PlayerPrefs.SetInt("SP", spCount);
        PlayerPrefs.SetInt("Level", playerLevel);
        PlayerPrefs.SetInt("Health", healthLevel);
        PlayerPrefs.SetInt("Strength", strengthLevel);
        PlayerPrefs.SetInt("Defense", defenseLevel);
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(5f);
        Respawn();
    }
}
