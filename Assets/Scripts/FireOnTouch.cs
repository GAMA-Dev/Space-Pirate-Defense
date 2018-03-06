using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnTouch : MonoBehaviour {

    private Fire fire;
    private void Start()
    {
        fire = GetComponent<Fire>();
    }
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                
                RaycastHit raycastHit;
                if (Physics.Raycast(ray, out raycastHit))
                {
                    if (raycastHit.collider.name == gameObject.name)
                    {
                        Debug.Log(gameObject.name + " clicked");
                        if (fire.canFire())
                        {
                            fire.fire();
                        }
                    }
                }
            }
            }
        }
    }

