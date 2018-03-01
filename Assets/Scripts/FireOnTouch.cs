using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnTouch : MonoBehaviour {

    public GameObject ammo;
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                // Create a particle if hit
                if (Physics.Raycast(ray))
                    Instantiate(ammo, transform.position, transform.rotation);
            }
        }
    }
}
