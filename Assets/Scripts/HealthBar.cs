using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // need to know where we are in life set in Start() - BeWaryOfMiscreant
    private Transform ThisTransform = null;
    private Transform ParentTransform = null;

    // points to the game object whose this healthbar tracks. set to the parent GameObject in Start() - BeWaryOfMiscreant
    public GameObject WhoseHealthExactly = null;

    // need to know how much life we have left,
    // so this references the actual health component. also set in Start() - BeWaryOfMiscreant
    private Health HealthRef = null;

    // we never resize the red bar, it is drawn behind the green bar
    // but it's transform is referenced for a handy way to keep track of the size of a FULL life bar. - BeWaryOfMiscreant

    private Transform RedBarTransform = null;
    private Transform GreenBarTransform = null;

    // used to hold the original value of the lifebar's local scale to prevent rounding errors from accumulating when scaling  - BeWaryOfMiscreant
    private Vector3 scalePreserver;

    // used to hold the lifebar's original position, for the same reason.
    private Vector3 translationPreserver;

    // used to hold the new dimensions of the lifebar's transform. - BeWaryOfMiscreant
    private Vector3 newScaleFactor;
    // used to hold the dimensions of the lifebar's transform before updating it. - BeWaryOfMiscreant
    private Vector3 preUpdateScaleFactor;

    void Start()
    {
        ThisTransform = GetComponent<Transform>();
        ParentTransform = ThisTransform.GetComponentInParent<Transform>();

        if (ThisTransform == null)
        {
            Debug.Log("No health bar transform.");
        }


        if (ParentTransform == null)
        {
            Debug.Log("No parent transform.");
        }

        WhoseHealthExactly = this.transform.parent.gameObject;

        if (WhoseHealthExactly == null)
        {
            Debug.Log("No parent component for healthbar.");
        }

        // check if parent gameobject has a HEALTH component.
        // if not, it doesn't make sense to have a health BAR, right? - BeWaryOfMiscreant
        HealthRef = WhoseHealthExactly.GetComponent<Health>();

        if (HealthRef == null)
        {
            Debug.Log(WhoseHealthExactly.name + " has a health bar but no health component! VERBOTEN!");
        }

        // Last, get the transform of the green bar so we can modify it during update. - BeWaryOfMiscreant

        Transform[] transforms = this.GetComponentsInChildren<Transform>();
        foreach (Transform t in transforms)
        {
            if (t.gameObject.name == "GreenFore")
            {
                GreenBarTransform = t.gameObject.transform;
            }
            if (t.gameObject.name == "RedBack")
            {
                RedBarTransform = t.gameObject.transform;
            }

        }

        if (GreenBarTransform == null)
        {
            Debug.Log("Failed to find green bar transform.");
        }

        if (RedBarTransform == null)
        {
            Debug.Log("Failed to find red bar transform.");
        }

        scalePreserver.x = GreenBarTransform.localScale.x;
        scalePreserver.y = GreenBarTransform.localScale.y;
        scalePreserver.z = GreenBarTransform.localScale.z;

        translationPreserver.x = GreenBarTransform.position.x;
        translationPreserver.y = GreenBarTransform.position.y;
        translationPreserver.z = GreenBarTransform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // save life bar dimensions before anything else - BeWaryOfMiscreant
        preUpdateScaleFactor.x = GreenBarTransform.localScale.x;
        preUpdateScaleFactor.y = GreenBarTransform.localScale.y;
        preUpdateScaleFactor.z = GreenBarTransform.localScale.z;

        // determine what the current scale factor should be, based on life total. - BeWaryOfMiscreant

        newScaleFactor.x = scalePreserver.x;
        newScaleFactor.y = scalePreserver.y * ((float)HealthRef.currentHealthPoints / (float)100);
        newScaleFactor.z = scalePreserver.z;




        Debug.Log("Calculating lifebar for gameObject: " + WhoseHealthExactly.GetInstanceID() + ", with health: " + HealthRef.currentHealthPoints);
        Debug.Log("New scale: " + newScaleFactor.y);

        GreenBarTransform.localScale = new Vector3(newScaleFactor.x, newScaleFactor.y, newScaleFactor.z);




    }
}
