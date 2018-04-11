using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int startingHealthPoints = 100;
    public int currentHealthPoints;
    public IDeathMethod deathMethod;

    public void Start()
    {
        deathMethod = gameObject.GetComponent<IDeathMethod>();
        currentHealthPoints = startingHealthPoints;
    }


    public void Damage(int amount)
    {
        currentHealthPoints -= amount;
        //Debug.Log(gameObject.name + "'s health is now " + currentHealthPoints);
        if (currentHealthPoints <= 0)
        {
            //gameObject.SetActive(false);
            //currentHealthPoints = startingHealthPoints;
            deathMethod.Die();
        }
    }

}
