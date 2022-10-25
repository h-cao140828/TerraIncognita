using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerCollider : MonoBehaviour
{
    public static bool hasCollide = false;

    public int currentWeaponDamage = 25;


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
