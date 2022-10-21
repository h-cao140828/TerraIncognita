using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerCollider : MonoBehaviour
{
    public bool hasCollide = false;

    public int currentWeaponDamage = 25;


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && !hasCollide)
        {
                hasCollide = true;

                PlayerStats playerStats = other.GetComponent<PlayerStats>();

                if (playerStats != null)
                {
                    playerStats.TakeDamage(currentWeaponDamage);
                }
        }
    }

    public void ResetHasCollider()
    {
        hasCollide = false;
    }
}
