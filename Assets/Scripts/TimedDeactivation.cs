using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeactivation : MonoBehaviour
{

    public float DeactivateTime = 2f;

    //------------------------------
    // Use this for initialization
    private void OnEnable()
    {
        Invoke("Deactivate", DeactivateTime);
    }

    // Update is called once per frame
    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
	//------------------------------
