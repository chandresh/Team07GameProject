using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action<int> OnLevelChanged;
    public static event Action OnGameWon;
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
    }

    private bool IsLevelChanged()
    {
        return CurrentLevel < levelDistances.Length && TotalDistanceTraveled >= levelDistances[CurrentLevel];
    }

    private bool IsGameWon()
    {
        return CurrentLevel >= levelDistances.Length;
    }

    private void ChangeLevel()
    {
        CurrentLevel++;
        if (IsGameWon())
        {
            OnGameWon?.Invoke();
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            OnLevelChanged?.Invoke(CurrentLevel);
        }
    }

}

