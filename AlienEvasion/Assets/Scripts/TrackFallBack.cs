using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackFallBack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        // If player touches the falloff trigger object - player dies
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("PlayerParts"))
        {
            Invoke("PlayerDied", 2.0f);
        }
    }


    void PlayerDied()
    {
        GameManager.PlayerDied();
    }



}
