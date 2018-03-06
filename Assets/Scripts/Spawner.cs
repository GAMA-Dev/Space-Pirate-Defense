//------------------------------
using UnityEngine;
//------------------------------
public class Spawner : MonoBehaviour
{
	public float Interval = 5f;
    public int laneWidth = 7;
    public int offset = -1;
    public string enemySpawnString = "a1b2a1b3b1a2c1c2c3";
	public GameObject Enemy0 = null;
    public GameObject Enemy1 = null;
    public GameObject Enemy2 = null;
    private System.CharEnumerator enemySpawnPattern;
	//------------------------------
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("Spawn", 0f, Interval);
        enemySpawnPattern = enemySpawnString.GetEnumerator();
    }
	//------------------------------
	void Spawn () 
	{
        GameObject ObjToSpawn = null;
        if (enemySpawnPattern.MoveNext())
        {
            switch (enemySpawnPattern.Current)
            {
                case 'a':
                    ObjToSpawn = Enemy0;
                    break;
                case 'b':
                    ObjToSpawn = Enemy1;
                    break;
                case 'c':
                    ObjToSpawn = Enemy2;
                    break;
                default:
                    ObjToSpawn = Enemy0;
                    break;
            }
        }
        else
        {
            CancelInvoke("Spawn");
        }

        int spawnLane;
        if (enemySpawnPattern.MoveNext())
        {
            switch (enemySpawnPattern.Current)
            {
                case '1':
                    spawnLane = (laneWidth * 1) + offset;
                    break;
                case '2':
                    spawnLane = 0 + offset;
                    break;
                case '3':
                    spawnLane = (laneWidth * -1) + offset;
                    break;
                default:
                    spawnLane = 0;
                    break;
            }
            Instantiate(ObjToSpawn, new Vector3(-20, 0, spawnLane),transform.rotation);

        }
        else
        {
            CancelInvoke("Spawn");
        }


    }
	//------------------------------
}
//------------------------------