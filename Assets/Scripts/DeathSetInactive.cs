using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSetInactive : MonoBehaviour, IDeathMethod {

    public void Die()
    {
        gameObject.SetActive(false);
        Health health = gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.currentHealthPoints = health.startingHealthPoints;
        }
    }

}
