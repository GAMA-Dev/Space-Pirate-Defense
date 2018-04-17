using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Turret", menuName = "Turret")]
public class TurretBluePrint : ScriptableObject{

    public GameObject[] levelPrefabs;

    public string buildMaterial;

    public int materialCost;

    public int currencyCost;

    public Sprite buildSprite;

    public int GetMaterialDropAmount()
    {
        return currencyCost / 2;
    }
}
