using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

    public GameObject dropPrefab;
    public int amount;
    public int dropChance;

    public bool Dropped() {
        return dropChance >= Random.Range(0, 100);
    }
    
    
}
