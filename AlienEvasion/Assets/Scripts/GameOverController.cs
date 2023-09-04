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
            
            //stop the game
            Time.timeScale = 0f;
            
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        GameManager.InitializeData();

    }

    public void RestartGame()
    {
        // Load the main menu scene by name (adjust the scene name as needed)
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
        GameManager.InitializeData();

    }

    // Other methods and variables can go here
}