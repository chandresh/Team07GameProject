using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static event Action<int> OnLevelChanged;
    public int CurrentLevel { get; private set; }
    public float TotalDistanceTraveled { get; set; }

    private readonly float[] levelDistances = { 1f, 3f, 6f, 10f, 15f };

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

    private void ChangeLevel()
    {
        CurrentLevel++;
        OnLevelChanged?.Invoke(CurrentLevel);
    }
}

