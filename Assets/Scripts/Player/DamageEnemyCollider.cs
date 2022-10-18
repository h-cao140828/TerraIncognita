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
        if (gameObject.transform.root.CompareTag("Player"))
        {
            playerCombat = gameObject.transform.root.GetComponentInChildren<PlayerCombat>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && playerCombat.isAttacking && !hasCollide)
        {
            hasCollide = true;

            EnemyStats enemyStats = other.GetComponent<EnemyStats>();
            Debug.Log(enemyStats.name);
            if (enemyStats != null)
            {
                enemyStats.TakeDamage(currentWeaponDamage);
            }
        }

    }

    private void LateUpdate()
    {
        ResetHasCollider();
    }

    public void ResetHasCollider()
    {
        hasCollide = false;
    }
}
