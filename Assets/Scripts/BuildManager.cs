using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    private TurretBluePrint selectedTurret;
    private List<TurretPlacement> turretPlacements = new List<TurretPlacement>();
    private List<TurretPlacement> buildablePlacements = new List<TurretPlacement>();

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
        
    }

    private void Start()
    {
        GameObject[] placementArray = GameObject.FindGameObjectsWithTag("Turret Placement");
        foreach (GameObject placement in placementArray)
        {
            //Debug.Log("Added " + placement.name + " to placement array");
            turretPlacements.Add(placement.GetComponent<TurretPlacement>());
        }
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        selectedTurret = turret;
        UpdateBuildablePlacements();
        ShowBuildablePlacements();
    }

    public void UpdateBuildablePlacements()
    {
        buildablePlacements.Clear();
        foreach (TurretPlacement placement in turretPlacements)
        {
            if (!placement.HasTurret)
            {
                Debug.Log(placement.name + " has been added to buildable placements");
                buildablePlacements.Add(placement);
            }
        }
    }

    public void ShowBuildablePlacements()
    {
        foreach (TurretPlacement buildablePlacement in buildablePlacements)
        {
            //Debug.Log("Showing " + buildablePlacement + "'s buildable sprite in Build Manager");
            buildablePlacement.ShowBuildable(selectedTurret);
        }
    }

    public void BuildTurret(TurretPlacement placement)
    {
        if (buildablePlacements.Contains(placement))
        {
            placement.BuildTurret(selectedTurret);
        }
    }

    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                RaycastHit raycastHit;
                if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, LayerMask.GetMask("Turret Placement")))
                {
                    TurretPlacement touchedPlacement = raycastHit.collider.gameObject.GetComponent<TurretPlacement>();
                    if (selectedTurret != null && buildablePlacements.Contains(touchedPlacement))
                    {
                        Debug.Log(gameObject.name + " clicked");
                        BuildTurret(touchedPlacement);
                        selectedTurret = null;
                        foreach (TurretPlacement placement in buildablePlacements)
                        {
                            placement.ClearBuildableSprite();
                        }
                        buildablePlacements.Clear();
                    }
                }
            }
        }
    }
}

