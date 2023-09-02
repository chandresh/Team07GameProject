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
    public int CurrentLevel { get; private set; }
    public float TotalDistanceTraveled { get; set; }

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
            OnLevelChanged?.Invoke(CurrentLevel);
        }
    }
}

