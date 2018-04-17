using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyTracker : MonoBehaviour
{
    public static CurrencyTracker instance;
    Dictionary<string, int> MaterialsDict = new Dictionary<string, int>();

    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one CurrencyTracker in scene!");
            return;
        }
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        MaterialsDict.Add("Currency", 0);  //currency/balance of currency
        MaterialsDict.Add("Spread", 0);    //spead item
        MaterialsDict.Add("Poison", 0);    //poison item
        MaterialsDict.Add("Piercing",0);   //piercing item
        MaterialsDict.Add("Explosive", 0); //explosive item
        MaterialsDict.Add("Energy", 0);    //energy item    
    }

    public int GetValue(string key) {
        if (MaterialsDict.ContainsKey("key")) {
            return MaterialsDict[key];
        }
        return 0;
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

    public bool CanAfford(string material, int cost) {
        if (MaterialsDict.ContainsKey(material)) { //if the key is valid
            if (MaterialsDict[material] >= cost) { //if the player has enough of the material/currency
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
