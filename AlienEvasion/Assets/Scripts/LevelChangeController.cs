using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeController : MonoBehaviour
{
    public GameObject levelChangePanel;
    private bool isPaused = false;

    public void ActivateLevelChangePanel()
    {
        if (levelChangePanel != null)
        {
            Time.timeScale = 0f;
            isPaused = true;
            levelChangePanel.SetActive(true);
        }
    }

    public void DeactivateLevelChangePanel()
    {
        if (levelChangePanel != null)
        {
            levelChangePanel.SetActive(false);
            if (isPaused)
            {
                Time.timeScale = 1f; // Resume the game
                isPaused = false;
            }
        }
    }

    public void LoadNextLevel()
    {
        DeactivateLevelChangePanel();

        // Notify the GameManager that the level has changed
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.NotifyLevelChanged();
        }
    }


    public void ClosePanel()
    {
        DeactivateLevelChangePanel();
    }
}
