using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour {

    public float reloadTime;
    public bool reloading = false;


    private void reload()
    {
        reloading = false;
    }
    public bool fireCannon()
    {
        if (!reloading)
        {
            reloading = true;
            Invoke("reload", reloadTime);
            return true;
        }
        return false;
    }
}
