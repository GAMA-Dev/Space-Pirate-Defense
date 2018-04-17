using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyTracker : MonoBehaviour
{
    Dictionary<string, int> MaterialsDict = new Dictionary<string, int>();
    
    // Use this for initialization
    void Start()
    {
        MaterialsDict.Add("currency", 0);  //currency/balance of currency
        MaterialsDict.Add("spread", 0);    //spead item
        MaterialsDict.Add("poison", 0);    //poison item
        MaterialsDict.Add("piercing",0);   //piercing item
        MaterialsDict.Add("explosive", 0); //explosive item
        MaterialsDict.Add("energy", 0);    //energy ite    
    }

    public bool Buy(string material, int cost) //method for subtracting material when buying
    {
        if (MaterialsDict.ContainsKey(material)) { //if the key is valid
            if (MaterialsDict[material] >= cost) { //if the player has enough of the material/currency
                MaterialsDict[material] -= cost;   //subtract the cost from the players inventory
                return true;
            }
        }
        return false;
    }


    //Add some money to the balance.
    public bool Add(string material,int amount)
    {
        if (MaterialsDict.ContainsKey(material)) {
            MaterialsDict[material] += amount;
            return true;
        }
        return false;
    }
}
