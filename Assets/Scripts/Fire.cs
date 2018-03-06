using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public AmmoManager ammoManager;

    public void fire()
    {
        ammoManager.SpawnAmmo(transform.position,transform.rotation);       
    }
}
