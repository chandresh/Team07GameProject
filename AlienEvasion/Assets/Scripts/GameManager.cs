using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action<int> OnLevelChanged;
    [SerializeField] Scrollbar levelScrollbar;
    public static event Action OnGameWon;
    public static event Action OnPlayerDeath;
    public static int CurrentLevel = 0;
    public static float TotalDistanceTraveled;

    // private readonly float[] levelDistances = { 1f, 3f, 6f, 10f, 14f, 20f };
    private readonly float[] levelDistances = { 1f, 2f, 3f, 4f, 5f, 6f };

    public void Update()
    {
        // Check for level changes
        if (IsLevelChanged())
        {
            ChangeLevel();
        }

        UpdateLevelUI();
    }

    void UpdateLevelUI()
    {
        if (levelScrollbar != null)
        {
            float levelDistance = levelDistances[CurrentLevel] * 100f;
            float totalCurrentDistance = TotalDistanceTraveled * 100f;
            levelScrollbar.size = totalCurrentDistance / levelDistance;
        }
    }

    private bool IsLevelChanged()
    {
        return CurrentLevel < levelDistances.Length && TotalDistanceTraveled >= levelDistances[CurrentLevel];
    }

    private bool IsGameWon()
    {
        return CurrentLevel >= levelDistances.Length;
    }

    public static void InitializeData()
    {
        CurrentLevel = 0;
        TotalDistanceTraveled = 0;
    }

    public static void PlayerDied()
    {
        OnPlayerDeath?.Invoke();
        GameOverController gameOverController = FindObjectOfType<GameOverController>();
        PlayerStatsController playerStatsController = FindObjectOfType<PlayerStatsController>();
        if (gameOverController != null && playerStatsController != null)
        {
            InitializeData();
            playerStatsController.ResetPlayerState();
            gameOverController.ActivateGameOverPanel();

        }

        //SceneManager.LoadScene("MainMenu");
        //// Reset the game data
        //InitializeData();
    }
    public void NotifyLevelChanged()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        OnLevelChanged?.Invoke(CurrentLevel);
    }

    private void ChangeLevel()
    {
        CurrentLevel++;
        if (IsGameWon())
        {
            OnGameWon?.Invoke();
            SceneManager.LoadScene("MainMenu");
            // Reset the game data
            InitializeData();
        }
        else
        {
            LevelChangeController levelChangeController = FindObjectOfType<LevelChangeController>();
            if (levelChangeController != null)
            {
                levelChangeController.ActivateLevelChangePanel();
            }
            //print(SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //OnLevelChanged?.Invoke(CurrentLevel);
        }
    }

}

