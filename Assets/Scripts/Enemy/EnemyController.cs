using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    DamagePlayerCollider damagePlayer;
    public bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        damagePlayer = GetComponentInChildren<DamagePlayerCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsAttacking()
    {
        isAttacking = true;
    }

    public void NotAttacking()
    {
        isAttacking = false;
        damagePlayer.ResetHasCollider();
    }
}
