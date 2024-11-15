using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI Title;
    public bool gameStarted = false; // To track if the game has started
    public SpawnManager spawnManager;

    void Start()
    {
        Time.timeScale = 0; // Pause the game initially
    }

    void Update()
    {
        // The game logic in Update can go here if needed
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        if (spawnManager != null)
        {
            spawnManager.StopSpawning();
        }
         // Pause the game on game over
    }

    public void StartGame()
    {
        gameStarted = true;
        Time.timeScale = 1; // Resume the game

        if (Title != null)
        {
            Title.gameObject.SetActive(false);
        }
    }
}
