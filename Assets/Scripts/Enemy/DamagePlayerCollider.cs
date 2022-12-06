using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamagePlayerCollider : MonoBehaviour
{
    public static bool hasCollide = false;

    [SerializeField] int currentWeaponDamage;
    

    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "ZoneOneEasy")
        {
            if (this.transform.name == "GoblinAttackArea")
                currentWeaponDamage = 7;
            else
                currentWeaponDamage = 12;
        }
        else
            if (this.transform.name == "GoblinAttackArea")
                currentWeaponDamage = 15;
            else
                currentWeaponDamage = 25;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && !hasCollide)
        {
                hasCollide = true;

                PlayerStats playerStats = other.GetComponent<PlayerStats>();
                PlayerCombat playerCombat = other.GetComponent<PlayerCombat>();

                if (playerStats != null)
                {
                    if (!playerCombat.isBlocking)
                        playerStats.TakeDamage(currentWeaponDamage);
                    else
                        playerStats.TakeReducedDamage(currentWeaponDamage);
                }
        }
    }

    public void ResetHasCollider()
    {
        hasCollide = false;
    }
}
