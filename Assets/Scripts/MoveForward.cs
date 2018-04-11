//------------------------------
//------------------------------
using UnityEngine;
using System.Collections;
//------------------------------
public class MoveForward : MonoBehaviour, IMovement
{
    //------------------------------
    public float MaxSpeed = 1f;

    public void Move()
    {
        transform.position += transform.forward * Time.deltaTime * MaxSpeed;
    }

    void Update()
    {
        Move();
    }
}
