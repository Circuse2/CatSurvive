using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameOver : MonoBehaviour
{

    public GameObject gameOverPanel;
    PauseManager pauseManager;


    private void Awake()
    {
        pauseManager = FindObjectOfType<PauseManager>();
    }

    public void GameOver()
    {
        pauseManager.PauseGame();
        GetComponent<Player>().movingSpeed = 0;
        gameOverPanel.SetActive(true);
    }
}
