using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBombController : MonoBehaviour
{
    // Destroy the bomb when it leaves the screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Destroy the bomb when it hits something
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);

        if (other.gameObject.CompareTag("PlayerParts"))
        {
            // Player got hit, decrease health by 10
            PlayerEventsManager.PlayerGotHit(-10);
        }
    }
}
