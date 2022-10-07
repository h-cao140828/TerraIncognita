using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    PlayerCombat playerCombat;
    //EnemyController enemy;

    //public GameObject hitParticle;
    bool hasCollide = false;

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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && playerCombat.isAttacking && !hasCollide)
        {
            Debug.Log(other.name);
            hasCollide = true;

            other.GetComponent<Animator>().SetTrigger("Hit");
            // for hit effects
            // Instantiate(hitParticle, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), other.transform.rotation);
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
