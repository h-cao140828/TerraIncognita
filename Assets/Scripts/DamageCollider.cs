using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    PlayerCombat playerCombat;
    EnemyController enemy;

    bool hasCollide = false;

    public int currentWeaponDamage = 25;

    // Start is called before the first frame update
    void Start()
    {
        // Checks who the damage collider belongs to
        if (gameObject.transform.root.CompareTag("Player"))
        {
            playerCombat = gameObject.transform.root.GetComponentInChildren<PlayerCombat>();
        }

        if (gameObject.transform.root.CompareTag("Enemy"))
        {
            //enemy = gameObject.transform.root.GetComponentInChildren<EnemyController>();
            enemy = gameObject.transform.root.GetComponent<EnemyController>();
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Enemy" && playerCombat.isAttacking && !hasCollide)
    //    {
    //        Debug.Log(other.name);
    //        hasCollide = true;

    //        other.GetComponent<Animator>().SetTrigger("Hit");

    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && playerCombat.isAttacking && !hasCollide)
        {
            Debug.Log("Enemy hi");
            hasCollide = true;

            EnemyStats enemyStats = other.GetComponent<EnemyStats>();

            if (enemyStats != null)
            {
                Debug.Log("Enemy got");
                enemyStats.TakeDamage(currentWeaponDamage);
            }
        }

        // enemy controller doesn't exist b/c weapon not attached to an enemy so may have to do in separate classes cause enemies can be of different types
        //if (other.tag == "Player" && enemy.isAttacking && !hasCollide)
        //{
        //    Debug.Log("player hi");
        //    hasCollide = true;

        //    PlayerStats playerStats = other.GetComponent<PlayerStats>();

        //    if (playerStats != null)
        //    {
        //        Debug.Log("player got");
        //        playerStats.TakeDamage(currentWeaponDamage);
        //    }
        //}
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
