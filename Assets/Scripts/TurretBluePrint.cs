using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Turret", menuName = "Turret")]
public class TurretBluePrint : ScriptableObject{

    public GameObject[] levelPrefabs;

    public GameObject buildMaterial;

    public int cost;

    public Sprite buildSprite;

    public int GetMaterialDropAmount()
    {
        return cost / 2;
    }
}
