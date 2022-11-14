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
    StarterAssets.ThirdPersonController controller;

    public GameObject shield;
    public Animator animator;
    public bool sheathed = true;
    public bool isAttacking = false;
    public bool isBlocking = false;

    // Start is called before the first frame update
    void Start()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        controller = GetComponent<StarterAssets.ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if a combat animation is played
        if (animator.GetCurrentAnimatorStateInfo(1).IsTag("Combat"))
        {
            // Prevents player from moving during the animation
            controller.UnableMove();
        }
        else
        {
            // Allows player to move if not performing a combat animation
            controller.AbleMove();
        }


        // Checks if the player is grounded
        if (controller.Grounded)
        {
            Combat();
            //Target();
        }
        Attack();
        Defend();
    }

    void Attack()
    {
        var keyboard = Keyboard.current;
        var mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame && !sheathed)
        {
            MeleeAttack();
        }

        // Checks if the player enter a keyboard key while having their weapon drawn
        //if (keyboard.digit1Key.wasPressedThisFrame && !sheathed)
        //{
        //    UseSkill(0);
        //}
        //if (keyboard.digit2Key.wasPressedThisFrame && !sheathed)
        //{
        //    UseSkill(1);
        //}
        //if (keyboard.digit3Key.wasPressedThisFrame && !sheathed)
        //{
        //    UseSkill(2);
        //}
        //if (keyboard.qKey.wasPressedThisFrame && !sheathed)
        //{
        //    PetSkill(0);
        //}
        //if (keyboard.eKey.wasPressedThisFrame && !sheathed)
        //{
        //    PetSkill(1);
        //}
    }

    void MeleeAttack()
    {
            // Plays an attack animation
            animator.SetTrigger("Attack");
            // Detect enemies in range of attack
            // Damage them
    }

    // A function for using player skills
    //void UseSkill(int skillKey)
    //{
    //    // Place holder 
    //    skillKey += 1;
    //    Debug.Log("No skill equipped on " + skillKey + " slot");

    //    // Plays the appropriate skill animation
    //    // Detects a target in range of skill
    //    // Applys the skill effect
    //}

    // A function for using companion skills
    //void PetSkill(int skillKey)
    //{
    //    // Place holder 
    //    skillKey += 1;
    //    Debug.Log("No pet skill equipped on " + skillKey + " slot");
    //    // Plays the appropriate skill
    //    // Detects a target in range of skill
    //    // Applys the skill effect
    //}

    void Defend()
    {
        var keyboard = Keyboard.current;
        var mouse = Mouse.current;
        // Checks if the player used a mouse button and has their weapon drawn
        if (mouse.rightButton.isPressed && !sheathed)
        {
            isBlocking = true;
            Block(isBlocking);
        }
        else if (mouse.rightButton.wasReleasedThisFrame && !sheathed)
        {
            isBlocking = false;
            Block(isBlocking);
        }


        //if (keyboard.leftCtrlKey.wasPressedThisFrame && !sheathed)
        //{
        //    DeployBarrier();
        //}
    }

    // A function for handling blocking
    void Block(bool blocking)
    {
        // Play the blocking animation
        animator.SetBool("Block", blocking);
        // Apply reduced damage taken
    }

    //void DeployBarrier()
    //{
    //    // Play the animation for deploying a barrier
    //    animator.SetTrigger("DeployBarrier");
    //    // Code for negating damage
    //    // Code for handling barrier cooldown
    //    // Code for destroying the barrier object
    //}

    //void Target()
    //{
    //    var keyboard = Keyboard.current;
    //    if (keyboard.tabKey.wasPressedThisFrame)
    //    {
    //        // Checks if the player has their weapon sheathed
    //        if (sheathed)
    //        {
    //            DrawWeapon();
    //            LockOn();
    //        }
    //        else
    //        {
    //            LockOn();
    //        }
    //    }
    //}

    //void LockOn()
    //{
    //    // Placeholder 
    //    Debug.Log("Targeting system not implemented yet");

    //    // Code to handle targeting a nearby attackable target
    //    // Code to cycle through available targets.
    //}

    void Combat()
    {
        var keyboard = Keyboard.current;
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
    }

    public void DrawWeapon()
    {
        sheathed = false;

        // Places shield into combat ready position
        shield.transform.localRotation = Quaternion.Euler(-20.104f, -194.27f, -254.195f);
        AudioManager.instance.Play("SwordDraw");
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

        // Places shield into normal position
        shield.transform.localRotation = Quaternion.Euler(-4.071f, -217.456f, -179.508f);
        // Play an animation
        animator.SetTrigger("SheathWeapon");
        // Place weapon in sheath
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        // Destroy weapon in hand
        Destroy(currentWeaponInHand);

    }

    public void IsAttacking()
    {
        isAttacking = true;
    }

    public void NotAttacking()
    {
        isAttacking = false;
    }

}
