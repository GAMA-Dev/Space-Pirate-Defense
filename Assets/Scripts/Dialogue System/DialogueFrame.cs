using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DialogueFrame {

    public Character characterLeft;
    public bool characterLeftIsSpeaking;

    public Character characterRight;
    public bool characterRightIsSpeaking;

    [TextArea(3,10)]
    public string dialogue;

}
