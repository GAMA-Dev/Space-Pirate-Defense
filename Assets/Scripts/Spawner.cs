//------------------------------
using UnityEngine;
using System.Collections;
//------------------------------
public class Spawner : MonoBehaviour
{
	public float Interval = 5f;
	public GameObject Enemy0 = null;
    public GameObject Enemy1 = null;
    public GameObject Enemy2 = null;
    public GameObject Enemy3 = null;
	//------------------------------
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("Spawn", 0f, Interval);
	}
	//------------------------------
	void Spawn () 
	{
        GameObject ObjToSpawn = null;
        int enemyType = (int)System.Math.Floor(Random.Range(0, 3f));
        switch (enemyType)
        {
            case 0:
                ObjToSpawn = Enemy0;
                break;
            case 1:
                ObjToSpawn = Enemy1;
                break;
            case 2:
                ObjToSpawn = Enemy2;
                break;
            case 3:
                ObjToSpawn = Enemy3;
                break;
            default:
                ObjToSpawn = Enemy0;
                break;
        }
        
		Instantiate(ObjToSpawn, new Vector3(-20,transform.position.y,transform.position.z), Quaternion.identity);
	}
	//------------------------------
}
//------------------------------