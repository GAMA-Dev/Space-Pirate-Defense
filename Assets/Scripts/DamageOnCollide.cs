using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour {

    public List<string> colliders;
    public int damageAmount;
    private Health health;
    private void OnTriggerEnter(Collider other)
    {
        if (colliders.Contains(other.tag))
        {
            health = other.GetComponent<Health>();
            if (health != null)
            {
                health.Damage(damageAmount);
            }
            gameObject.SetActive(false);
        }
    }
}
