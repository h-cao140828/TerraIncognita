using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStats : EnemyStats
{
    private void Awake()
    {
        healthLevel = 20;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
