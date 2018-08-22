using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpToTarget : MonoBehaviour {
    public bool startLerp;
    public string targetTag;
    public int smoothfactor;
    private GameObject target;

    private void Awake() {
        target = GameObject.FindGameObjectWithTag(targetTag);
    }

    // Update is called once per frame
    void Update () {
        if (startLerp) {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * smoothfactor);
        }
    }
}
