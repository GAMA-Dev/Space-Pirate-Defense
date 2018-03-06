using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour {

    //------------------------------
    //Reference to ammo prefab
    public GameObject AmmoPrefab = null;

    //Ammo pool count
    public int PoolSize = 20;

    public Queue<Transform> AmmoQueue = new Queue<Transform>();

    //Array of ammo objects to generate
    private GameObject[] AmmoArray;

    //------------------------------
    // Use this for initialization
    void Awake()
    {
        AmmoArray = new GameObject[PoolSize];

        for (int i = 0; i < PoolSize; i++)
        {
            AmmoArray[i] = Instantiate(AmmoPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            Transform ObjTransform = AmmoArray[i].GetComponent<Transform>();
            ObjTransform.parent = GetComponent<Transform>();
            AmmoQueue.Enqueue(ObjTransform);
            AmmoArray[i].SetActive(false);
        }


    }
    //------------------------------
    public Transform SpawnAmmo(Vector3 Position, Quaternion Rotation)
    {
        //Get ammo
        Transform SpawnedAmmo = this.AmmoQueue.Dequeue();

        SpawnedAmmo.gameObject.SetActive(true);
        SpawnedAmmo.position = Position;
        SpawnedAmmo.localRotation = Rotation;

        //Add to queue end
        this.AmmoQueue.Enqueue(SpawnedAmmo);

        //Return ammo
        return SpawnedAmmo;
    }
    //------------------------------
}
