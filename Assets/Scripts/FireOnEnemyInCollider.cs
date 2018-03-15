using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnEnemyInCollider : MonoBehaviour {

    Fire fire;
    Transform target = null;
    List<Transform> enemiesInRange = new List<Transform>();
    public GameObject turret;


    private void Awake()
    {
        fire = turret.GetComponent<Fire>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //if collider entering this objects collider is tagged as a enemy
        if (other.CompareTag("Enemy"))
        {
            //adds this enemy to the enemy queue
            enemiesInRange.Add(other.transform);
            //if this object doesn't currently have a target
            if (target == null)
            {
                //target becomes the first enemy in the queue
                target = enemiesInRange[0];
                Debug.Log(other.name + " is now the target of " + gameObject.name);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if the object leaving the collider is an enemy
        if (other.CompareTag("Enemy"))
        {
            //removes the enemy from the queue
            enemiesInRange.Remove(other.transform);
            //if there are any other enemies in range
            if (enemiesInRange.Count > 0)
            {
                Debug.Log(enemiesInRange[0].name + " is now the target of " + gameObject.name);
                //retargets the enemy currently at the top of the queue
                target = enemiesInRange[0];
            }
            else
            {
                target = null;
            }
        }
    }

    private void Update()
    {
        
        //if target is not null
        if (target)
        {
            if (target.gameObject.activeSelf)
            {
                //point turret at target
                turret.transform.LookAt(target);
                //if turret can fire
                if (fire.canFire())
                {
                    fire.fire();
                }
            }
            else
            {
                enemiesInRange.Remove(target.transform);
                if (enemiesInRange.Count > 0)
                {
                    Debug.Log(enemiesInRange[0].name + " is now the target of " + gameObject.name);
                    //retargets the enemy currently at the top of the queue
                    target = enemiesInRange[0];
                }
                else
                {
                    target = null;
                }
            }
        }
    }

}
