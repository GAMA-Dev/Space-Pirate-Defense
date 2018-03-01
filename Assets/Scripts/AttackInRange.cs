using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInRange : MonoBehaviour {

    public float coolDown;
    public float range;
    private Transform target = null;

    private void Start()
    {
        InvokeRepeating("Attack", 0, coolDown);
    }
    void Attack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
        int i = 0;
        float closest = 0;
        if (hitColliders.Length > 0)
        {
            target = hitColliders[0].transform;
            closest = Vector3.Distance(transform.position, target.transform.position);

        }
        else
        {
            target = null;
        }
        while (i < hitColliders.Length)
        {
            float current = Vector3.Distance(transform.position, hitColliders[i].transform.position);
            if (closest > current)
            {
                closest = current;
                target = hitColliders[i].transform;
            }
            i++;
        }
    }
    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }
}
