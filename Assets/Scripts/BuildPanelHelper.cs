using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPanelHelper : MonoBehaviour {

    bool isVisible = false;
    public void togglePanel() {
        isVisible = !isVisible;
        GetComponent<Animator>().SetBool("showBuildPanel", isVisible);
    }
}
