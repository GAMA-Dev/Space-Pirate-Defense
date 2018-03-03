using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour {

    public float reloadTime;
    public bool reloading = false;

    //reload is called by the public canFire method after reloadTime is up, essentially when object is done reloading
    private void reload()
    {
        reloading = false;
    }

    //called by fireOnTouch, could be called from other scripts as well on other objects needing a reload timer 
    public bool canFire()
    {
        //if object is not currently reloading
        if (!reloading)
        {
            //object now needs to reload
            reloading = true;
            //object will be reloaded after reloadTime is up
            Invoke("reload", reloadTime);
            //tell calling script that the object can fire
            return true;
        }
        //object is reloading, tell calling script the object cannot fire
        else
        {
            return false;
        }
    }
}
