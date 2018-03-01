using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {


    public Vector2 startPos;
    public Vector2 direction;
    public Vector3 destination;
    public float maxspeed;
    public float smoothfactor;
    public bool useLerp;
    public bool directionChosen;
    public int laneWidth = 7;

    private void Start()
    {
        destination = transform.position;
    }
    void Update()
    {
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }
        if (directionChosen)
        {
            directionChosen = false;
            if (direction.y > 0)
            {
                destination.z = Mathf.Clamp(destination.z + laneWidth, 0, laneWidth);
                
            }
            else
            {
                destination.z = Mathf.Clamp(destination.z - laneWidth, -laneWidth, 0);
            }
        }
        if (transform.position != destination)
        {
            if (useLerp)
            {
                if (Mathf.Abs(transform.position.z - destination.z) < 0.1f)
                {
                    transform.position = destination;
                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * smoothfactor);
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, maxspeed);
            }
        }
    }
}


