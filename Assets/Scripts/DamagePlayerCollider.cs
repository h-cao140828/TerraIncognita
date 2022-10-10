using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerCollider : MonoBehaviour
{
    EnemyController enemy;

    bool hasCollide = false;

    public int currentWeaponDamage = 25;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.transform.root.CompareTag("Enemy"))
        {
            //enemy = gameObject.transform.root.GetComponentInChildren<EnemyController>();
            enemy = gameObject.transform.root.GetComponent<EnemyController>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && enemy.isAttacking && !hasCollide)
        {
            Debug.Log("player hi");
            hasCollide = true;

            PlayerStats playerStats = other.GetComponent<PlayerStats>();

            if (playerStats != null)
            {
                Debug.Log("player got");
                playerStats.TakeDamage(currentWeaponDamage);
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
