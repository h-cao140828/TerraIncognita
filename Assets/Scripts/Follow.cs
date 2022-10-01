using System. Collections;
using System. Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public GameObject Player;
    public float TargetDistance;
    public float AllowedDistance = 5;
    public GameObject Fox;
    public float FollowSpeed;
    public RaycastHit Shot;
    
    void Update () {
        
        transform.LookAt(Player.transform);
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out Shot) ) {
            
            TargetDistance = Shot.distance;
            if (TargetDistance >= AllowedDistance) {
                
                FollowSpeed = 0.01f;
                Fox.GetComponent<Animation>().Play("Fox_Run");
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, FollowSpeed);
            }
            else {
                    
                FollowSpeed = 0;
                Fox.GetComponent<Animation>().Play("Fox_Idle");
            }
        }
    }
}