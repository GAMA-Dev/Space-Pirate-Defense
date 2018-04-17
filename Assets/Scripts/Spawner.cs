//------------------------------
using UnityEngine;
//------------------------------
public class Spawner : MonoBehaviour
{
	public float Interval = 5f;
    public int laneWidth = 7;
    public int offset = -1;
    public string enemySpawnString = "a1b2a1b3b1a2c1c2c3";
	public GameObject EnemyA;
    public GameObject EnemyB;
    public GameObject EnemyC;
    private System.CharEnumerator enemySpawnPattern;
    private string theMethod = "Spawn";
	//------------------------------
	// Use this for initialization
	void Start () 
	{

		InvokeRepeating(theMethod, 0f, Interval);
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
                    ObjToSpawn = EnemyA;
                    break;
                case 'b':
                    ObjToSpawn = EnemyB;
                    break;
                case 'c':
                    ObjToSpawn = EnemyC;
                    break;
                default:
                    ObjToSpawn = EnemyA;
                    break;
            }
        }
        else
        {
            CancelInvoke(theMethod);
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
            GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject(ObjToSpawn.name);
            if (enemy != null)
            {
                enemy.transform.position = new Vector3(-25, 0, spawnLane);
                enemy.transform.rotation = transform.rotation;
                enemy.SetActive(true);
            }
        }
        else
        {
            CancelInvoke(theMethod);
        }


    }
	//------------------------------
}
//------------------------------