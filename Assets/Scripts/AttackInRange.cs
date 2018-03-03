using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInRange : MonoBehaviour {

    public float coolDown;
    public float range;
    private Transform target = null;

     
    private void Awake()
    {
        //when script is  initialized, the object starts trying to find a new target every cooldown period
        InvokeRepeating("Attack", 0, coolDown);
    }

    void Attack()
    {
        //Creates an array of all colliders touching or inside a sphere with radius of the range variable
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
        float closest = 0;
        //if any colliders are found
        if (hitColliders.Length > 0)
        {
            //sets target to the first collider found, to have something to compare to
            target = hitColliders[0].transform;
            //sets closest to the distance to the current target
            closest = Vector3.Distance(transform.position, target.transform.position);
            //skipping the first collider as we already used it above, this goes through any remaining colliders to find the closest one
            for (int i = 1; i < hitColliders.Length; i++)
            {
                //gets the distance to the current collider from the center of this object
                float current = Vector3.Distance(transform.position, hitColliders[i].transform.position);
                //if the distance to the current collider is shorter than the previous shortest distance, then it becomes the new closest
                if (current < closest)
                {
                    //new closest target is assigned
                    closest = current;
                    target = hitColliders[i].transform;
                }
            }
        }
        //if no colliders were found
        else
        {
            target = null;
        }
        

    }
    private void Update()
    {
        //points object at target while it has a target in range
        if (target != null)
        {
            transform.LookAt(target);
        }
    }
}
