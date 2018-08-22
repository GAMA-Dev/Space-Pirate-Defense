using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDropItems : MonoBehaviour, IDeathMethod {

    public void Die()
    {
        gameObject.SetActive(false);
        Health health = gameObject.GetComponent<Health>();
        Drop[] drops = gameObject.GetComponents<Drop>();
        if (health != null)
        {
            health.currentHealthPoints = health.startingHealthPoints;
        }
        if (drops != null) {
            for (int i = 0; i < drops.Length; i++) {
                if (drops[i].Dropped()) {
                    GameObject newdrop = Instantiate(drops[i].dropPrefab, transform.position + new Vector3(i, 0, 0), Quaternion.identity);
                    newdrop.GetComponent<Value>().Init(drops[i].amount);
                }
            }
        }

    }

}
