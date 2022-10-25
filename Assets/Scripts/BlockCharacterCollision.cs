using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCharacterCollision : MonoBehaviour
{
    public Collider characterCollider;
    public BoxCollider characterBlockerCollider;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(characterCollider, characterBlockerCollider, true);
    }
}
