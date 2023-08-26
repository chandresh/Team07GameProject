using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEventsManager : MonoBehaviour
{
    public static event Action<int> OnPlayerGotHit;
    public static event Action<Vector3> OnPlayerLoseLife;
    public static event Action<int> OnPlayerGainsCurrency;
    public static event Action<int> OnPlayerFuelChange;
    public static event Action<int> OnPlayerShieldChange;

    public static void PlayerGotHit(int healthAmount)
    {
        OnPlayerGotHit?.Invoke(healthAmount);
    }

    public static void PlayerLostLife(Vector3 position)
    {
        OnPlayerLoseLife?.Invoke(position);
    }

    public static void PlayerGainsCurrency(int amount)
    {
        OnPlayerGainsCurrency?.Invoke(amount);
    }

    public static void PlayerFuelChange(int amount)
    {
        OnPlayerFuelChange?.Invoke(amount);
    }

    public static void PlayerShieldChange(int shieldAmount)
    {
        OnPlayerShieldChange?.Invoke(shieldAmount);
    }
}
