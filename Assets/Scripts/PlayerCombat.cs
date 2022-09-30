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
    bool sheathed = true;

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


            // Perform an attack if the player's weapon is drawn and left clicks
            var mouse = Mouse.current;
            if (mouse.leftButton.wasPressedThisFrame && !sheathed)
            {
                animator.SetTrigger("Attack");
            }
        }
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
       
    }

    // A function for using player skills

    // A function for using companion skills

    public void DrawWeapon()
    {
        //draw = true;
        sheathed = false;
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
        // Play an animation
        animator.SetTrigger("SheathWeapon");
        // Place weapon in sheath
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        // Destroy weapon in hand
        Destroy(currentWeaponInHand);

    }

}
