using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemyCollider : MonoBehaviour
{
    PlayerCombat playerCombat;
    PlayerStats playerStats;

    bool hasCollide = false;

    // Start is called before the first frame update
    void Start()
    {
        playerCombat = gameObject.transform.root.GetComponentInChildren<PlayerCombat>();
        playerStats = gameObject.transform.root.GetComponentInChildren<PlayerStats>();


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && playerCombat.isAttacking && !hasCollide)
        {
            hasCollide = true;
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                AudioManager.instance.Play("SwordHit");
                enemy.TakeDamage(playerStats.attackDamage);
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
