using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnTouch : MonoBehaviour {

    private Reload reload;
    private void Start()
    {
        reload = GetComponent<Reload>();
    }
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                // Create ammo instance this object is hit
                RaycastHit raycastHit;
                if (Physics.Raycast(ray, out raycastHit))
                {
                    if (raycastHit.collider.name == gameObject.name)
                    {
                        Debug.Log(gameObject.name + " clicked");
                        if (reload.canFire())
                        {
                            SendMessage("fire");
                        }
                    }
                }
            }
            }
        }
    }

