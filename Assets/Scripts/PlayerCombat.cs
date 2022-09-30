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
    public Animator animator;
    bool combat = false;
    bool draw = false;
    bool sheathed = true;

    // Melee combo related variables
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0f;
    float maxComboDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
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
            // inside loop check if sheathed
            // if yes, draw sword
            // else, sheath sword
            // outside loop do combat stuff like attack handles melee
        //    // Enter combat if "T" key was pressed
        //    if (keyboard.tKey.wasPressedThisFrame && !draw)
        //    {
        //        DrawWeapon();
        //    }
        //    else
        //    {
        //        SheathWeapon();
        //    }
        }

        //if (combat)
        //{
        //    MeleeAttack();
        //}

    }

    void Attack()
    {
        // Play an attack animation
        animator.SetTrigger("Attack");
        // Detect enemies in range of attack
        // Damage them
    }

    // A function for using melee attacks
    void MeleeAttack()
    {
        // Check if player stop clicking and ends animation
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            animator.SetBool("hit1", false);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            animator.SetBool("hit2", false);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("hit3"))
        {
            animator.SetBool("hit3", false);
            noOfClicks = 0;
        }

        // Check for cooldown 
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }
        if (Time.time > nextFireTime)
        {
            var mouse = Mouse.current;
            if (mouse.leftButton.wasPressedThisFrame)
            {
                OnClick();
            }
        }
    }

    // A function for using player skills

    // A function for using companion skills

    public void DrawWeapon()
    {
        //draw = true;
        sheathed = false;
        // Play an animation
        animator.SetTrigger("drawWeapon");
        // Place weapon in hand
        currentWeaponInHand = Instantiate(weapon, weaponHolder.transform);
        // Destroy the weapon in sheath
        Destroy(currentWeaponInSheath);

        // Enter combat
        //EnterCombat();
    }

    public void SheathWeapon()
    {
        sheathed = true;
        // Play an animation
        animator.SetTrigger("sheathWeapon");
        // Place weapon in sheath
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        // Destroy weapon in hand
        Destroy(currentWeaponInHand);

        // Exit combat
        //ExitCombat();
    }

    // Attacks and mechanics relating to combat should be called here
    public void EnterCombat()
    {
        combat = true;
        // attack


        var keyboard = Keyboard.current;
        if (keyboard.tKey.wasPressedThisFrame)
        {
            SheathWeapon();
        }
    }

    public void ExitCombat()
    {
        combat = false;

    }

    void OnClick()
    {
        // Play an attack animation
        lastClickedTime = Time.time;
        noOfClicks++;
        if (noOfClicks == 1)
        {
            animator.SetBool("hit", true);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if (noOfClicks >= 2 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            animator.SetBool("hit1", false);
            animator.SetBool("hit2", true);
        }

        if (noOfClicks >= 3 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            animator.SetBool("hit2", false);
            animator.SetBool("hit3", true);
        }

        // Detect enemies in range of attack
        // Damage them
    }
}
