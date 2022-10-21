using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemyCollider : MonoBehaviour
{
    PlayerCombat playerCombat;

    bool hasCollide = false;

    public int currentWeaponDamage = 25;

    // Start is called before the first frame update
    void Start()
    {
            playerCombat = gameObject.transform.root.GetComponentInChildren<PlayerCombat>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && playerCombat.isAttacking && !hasCollide)
        {
            hasCollide = true;
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(currentWeaponDamage);
            }
        }

    }

    private void Update()
    {
        ResetHasCollider();
    }

    public void ResetHasCollider()
    {
        hasCollide = false;
    }
}
