using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //collision testing for future damage scripts
            Debug.Log("Enemy Hit Ship");
            other.gameObject.SetActive(false);
        }
    }
}
