using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginButton : MonoBehaviour
{
    private Button button;
    public GameManager gameManager; // Assign this in the Inspector

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        if (gameManager != null)
        {
            gameManager.StartGame(); // Start the game through the GameManager
            gameObject.SetActive(false); // Hide the button after starting
        }
        else
        {
            Debug.LogError("GameManager reference is not set in BeginButton.");
        }
    }
}
