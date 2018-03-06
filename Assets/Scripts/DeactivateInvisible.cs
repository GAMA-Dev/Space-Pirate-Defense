using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateInvisible : MonoBehaviour {


    private void OnBecameInvisible()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
