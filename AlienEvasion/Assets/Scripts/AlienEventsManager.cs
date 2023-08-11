using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlienEventsManager : MonoBehaviour
{
    public static event Action OnAlienGotHit;
    public static void AlienIsHit()
    {
        OnAlienGotHit?.Invoke();
    }
}
