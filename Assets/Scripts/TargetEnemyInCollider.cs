using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemyInCollider : MonoBehaviour {

    Reload reload;
    GameObject target = null;
    List<GameObject> enemiesInRange = new List<GameObject>();
    public GameObject turret;


    private void Awake()
    {
        reload = turret.GetComponent<Reload>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //if collider entering this objects collider is tagged as a enemy
        if (other.CompareTag("Enemy"))
        {
            //adds this enemy to the enemy queue
            enemiesInRange.Add(other.gameObject);
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
            enemiesInRange.Remove(other.gameObject);
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
            //point turret at target
            turret.transform.LookAt(target.transform);
            //if turret can fire
            if (reload.canFire())
            {
                //call fire method on any script attached to turret 
                turret.SendMessage("fire");
            }
        }
    }

}
