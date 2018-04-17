using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpToTarget : MonoBehaviour {
    public bool startLerp;
    public GameObject target;
    public int smoothfactor;

    // Update is called once per frame
    void Update () {
        if (startLerp) {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * smoothfactor);
        }
    }
}
