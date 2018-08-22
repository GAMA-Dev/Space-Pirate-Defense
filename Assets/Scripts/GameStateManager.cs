using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour {

    public string nextlevel;
    public Spawner spawner;
    public GameObject winPanel;


    // Update is called once per frame
    void Update () {
        if (spawner.doneSpawning) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0) {
                Invoke("GoToNextLevel", 3);
                winPanel.GetComponentInChildren<Text>().text = "Level Complete";
                winPanel.SetActive(true);
            }
        }	
	}

    private void GoToNextLevel() {
        SceneManager.LoadScene(nextlevel);
    }
}
