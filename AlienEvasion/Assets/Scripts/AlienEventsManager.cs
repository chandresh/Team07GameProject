using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// This class is used to manage events related to the alien
public class AlienEventsManager : MonoBehaviour
{

    // Event for when the alien is hit
    public static event Action OnAlienGotHit;
    public static void AlienIsHit()
    {
        OnAlienGotHit?.Invoke();
    }
}
