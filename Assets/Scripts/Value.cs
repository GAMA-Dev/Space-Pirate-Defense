using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Value : MonoBehaviour {

    private int value;
    

    private void Awake() {
        value = 1;
    }

    public void Init(int initValue) {
        value = initValue;
    }

    public int GetValue() {
        return value;
    }
}
