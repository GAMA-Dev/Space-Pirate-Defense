using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int healthPoints = 100;
    
    
    public void Damage(int amount)
    {
        healthPoints -= amount;
        Debug.Log(gameObject.name + "'s health is now " + healthPoints);
        if (healthPoints <= 0)
        {
            gameObject.SetActive(false);
            
        }
    }

}
