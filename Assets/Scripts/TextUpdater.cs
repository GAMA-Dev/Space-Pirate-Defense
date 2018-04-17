using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour {

    public string materialKey;
    Text text;
    private void Awake() {
        text = gameObject.GetComponent<Text>();
    }
    // Update is called once per frame
    void Update () {
         text.text = CurrencyTracker.instance.GetValue(materialKey).ToString();
	}
}
