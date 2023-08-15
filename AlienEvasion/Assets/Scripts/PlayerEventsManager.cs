using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEventsManager : MonoBehaviour
{
    public static event Action<int> OnPlayerGotHit;
    public static event Action<Vector3> OnPlayerLoseLife;

    public static void PlayerGotHit(int healthAmount)
    {
        OnPlayerGotHit?.Invoke(healthAmount);
    }

    public static void PlayerLostLife(Vector3 position)
    {
        OnPlayerLoseLife?.Invoke(position);
    }
}
