using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverPanel;
    //public GameManager gameManager;

    // Activate the game over panel
    public void ActivateGameOverPanel()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    // Deactivate the game over panel
    public void DeactivateGameOverPanel()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    // Return to the main menu
    public void ReturnToMainMenu()
    {
        // Load the main menu scene by name (adjust the scene name as needed)
        
        SceneManager.LoadScene("MainMenu");
        GameManager.InitializeData();
        // Reset any game data or player stats as needed
        // Call InitializeData() or similar methods if necessary

    }

    public void RestartGame()
    {
        // Load the main menu scene by name (adjust the scene name as needed)
       
        SceneManager.LoadScene("MainScene");
        GameManager.InitializeData();

    }

    // Other methods and variables can go here
}