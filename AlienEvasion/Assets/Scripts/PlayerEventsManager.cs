using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEventsManager : MonoBehaviour
{
    public static event Action OnPlayerGotHit;
    public static event Action<Vector3> OnPlayerLoseLife;

    public static void PlayerGotHit()
    {
        OnPlayerGotHit?.Invoke();
    }

    public static void PlayerLostLife(Vector3 position)
    {
        OnPlayerLoseLife?.Invoke(position);
    }
}
