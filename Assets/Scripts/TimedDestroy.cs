//------------------------------
using UnityEngine;
using System.Collections;
//------------------------------
public class TimedDestroy : MonoBehaviour 
{
	public float DestroyTime = 2f;

	//------------------------------
	// Use this for initialization
	void Start ()
	{
		Invoke("Die", DestroyTime);
	}
	
	// Update is called once per frame
	void Die () 
	{
		Destroy(gameObject);
	}
	//------------------------------
}
//------------------------------