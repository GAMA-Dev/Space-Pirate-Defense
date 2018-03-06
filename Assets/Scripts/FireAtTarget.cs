using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtTarget : MonoBehaviour {

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.forward, Time.deltaTime * 5);
    }
}
