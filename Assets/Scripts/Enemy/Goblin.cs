using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    private void Awake()
    {
        healthLevel = 10;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
