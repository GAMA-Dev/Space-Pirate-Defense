using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour {

    private TurretBluePrint turretBluePrint;

    private GameObject turretUpgradeLevel;

    private SpriteRenderer rend;

    public bool HasTurret
    {
        get { return turretBluePrint != null; }
    }

    private void Awake()
    {
        rend = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    public void ShowBuildable(TurretBluePrint turret)
    {
        rend.sprite = turret.buildSprite;
    }

    public void ClearBuildableSprite()
    {
        rend.sprite = null;
    }

    public void BuildTurret(TurretBluePrint turretToBuild)
    {
        turretBluePrint = turretToBuild;
        Instantiate(turretBluePrint.levelPrefabs[0],transform);
        ClearBuildableSprite();
    }

}
