//------------------------------
//------------------------------
using UnityEngine;
using System.Collections;
//------------------------------
public class Mover : MonoBehaviour
{
    //------------------------------
    public float MaxSpeed = 1f;
    //------------------------------

    //------------------------------
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * MaxSpeed;
    }
}
