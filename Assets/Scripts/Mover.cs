//------------------------------
//------------------------------
using UnityEngine;
using System.Collections;
//------------------------------
public class Mover : MonoBehaviour
{
    //------------------------------
    public float MaxSpeed = 1f;
    public Vector3 direction;
    //------------------------------

    //------------------------------
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position+direction, MaxSpeed);
    }
}
