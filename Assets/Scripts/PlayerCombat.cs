using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] GameObject weaponHolder;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject weaponSheath;

    GameObject currentWeaponInHand;
    GameObject currentWeaponInSheath;

    public GameObject combatShield;
    public GameObject movementShield;
    public Animator animator;
    public bool sheathed = true;

    // Start is called before the first frame update
    void Start()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        var mouse = Mouse.current;
        if (keyboard != null)
        {
            // check if press "T"
            if (keyboard.tKey.wasPressedThisFrame)
            {
                if (sheathed)
                {
                    DrawWeapon();
                }
                else
                {
                    SheathWeapon();
                }
            }

            if (keyboard.tabKey.wasPressedThisFrame)
            {
                // Checks if the player has their weapon sheathed
                if (sheathed)
                {
                    DrawWeapon();
                    Target();
                }
                else
                {
                    Target();
                }
            }

            // Checks if the player used a mouse button and has their weapon drawn
            if (mouse.rightButton.isPressed && !sheathed)
            {
                Block(true);
            }
            else if (mouse.rightButton.wasReleasedThisFrame && !sheathed)
            {
                Block(false);
            }

            if (mouse.leftButton.wasPressedThisFrame && !sheathed)
            {
                MeleeAttack();
            }

            // Checks if the player enter a keyboard key while having their weapon drawn
            if (keyboard.digit1Key.wasPressedThisFrame && !sheathed)
            {
                UseSkill(0);
            }
            if (keyboard.digit2Key.wasPressedThisFrame && !sheathed)
            {
                UseSkill(1);
            }
            if (keyboard.digit3Key.wasPressedThisFrame && !sheathed)
            {
                UseSkill(2);
            }
            if (keyboard.qKey.wasPressedThisFrame && !sheathed)
            {
                PetSkill(0);
            }
            if (keyboard.eKey.wasPressedThisFrame && !sheathed)
            {
                PetSkill(1);
            }
            if (keyboard.leftCtrlKey.wasPressedThisFrame && !sheathed)
            {
                DeployBarrier();
            }

        }
    }

    void MeleeAttack()
    {
            // Plays an attack animation
            animator.SetTrigger("Attack");
            // Detect enemies in range of attack
            // Damage them
    }

    // A function for using player skills
    void UseSkill(int skillKey)
    {
        // Place holder 
        skillKey += 1;
        Debug.Log("No skill equipped on " + skillKey + " slot");

        // Plays the appropriate skill animation
        // Detects a target in range of skill
        // Applys the skill effect
    }

    // A function for using companion skills
    void PetSkill(int skillKey)
    {
        // Place holder 
        skillKey += 1;
        Debug.Log("No pet skill equipped on " + skillKey + " slot");
        // Plays the appropriate skill
        // Detects a target in range of skill
        // Applys the skill effect
    }

    // A function for handling blocking
    void Block(bool blocking)
    {
        // Play the blocking animation
        animator.SetBool("Block", blocking);
        // Apply reduced damage taken
    }

    void DeployBarrier()
    {
        // Play the animation for deploying a barrier
        animator.SetTrigger("DeployBarrier");
        // Code for negating damage
        // Code for handling barrier cooldown
        // Code for destroying the barrier object
    }

    void Target()
    {
        // Placeholder 
        Debug.Log("Targeting system not implemented yet");

        // Code to handle targeting a nearby attackable target
        // Code to cycle through available targets.
    }

    public void DrawWeapon()
    {
        sheathed = false;

        // Disables the shield used for regular movement
        movementShield.SetActive(false);
        // Enables the shield used for combat
        combatShield.SetActive(true);
        // Play an animation
        animator.SetTrigger("DrawWeapon");
        // Place weapon in hand
        currentWeaponInHand = Instantiate(weapon, weaponHolder.transform);
        // Destroy the weapon in sheath
        Destroy(currentWeaponInSheath);
    }

    public void SheathWeapon()
    {
        sheathed = true;

        // Disables the shield used for combat
        combatShield.SetActive(false);
        // Enables the shield used for regular movement
        movementShield.SetActive(true);
        // Play an animation
        animator.SetTrigger("SheathWeapon");
        // Place weapon in sheath
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        // Destroy weapon in hand
        Destroy(currentWeaponInHand);

    }

}
