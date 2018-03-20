using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEventTrigger : MonoBehaviour {

    public DialogueManager dialogueManager;

    public void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void UpdateSprites()
    {
        dialogueManager.UpdateSprites();
    }
}
