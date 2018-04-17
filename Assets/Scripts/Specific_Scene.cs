using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Specific_Scene : MonoBehaviour {
    public string Desired_Level;
    public Button PushButton;

    void Start()
    {
        Button btn = PushButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
    //Desired_Level is specified in the editor
        SceneManager.GetSceneByName(Desired_Level);
    }
}
