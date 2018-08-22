using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathGameOver : MonoBehaviour, IDeathMethod {
    public string currentLevel;
    public GameObject gameOverPanel;
    public void Die()
    {
        Invoke("GameOver", 3);
        //Time.timeScale = 0;
        gameOverPanel.GetComponentInChildren<Text>().text = "Game Over";
        gameOverPanel.SetActive(true);
    }

    private void GameOver() {
        SceneManager.LoadScene(currentLevel);
    }

}
