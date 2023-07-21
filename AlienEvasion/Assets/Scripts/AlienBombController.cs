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
            // Find and destroy the object with tag "Player"
            //GameObject player = GameObject.FindWithTag("Player");
            //Destroy(player);

            // gets the player stats controller and calls change health
            // reducing the players health by 10
            GameObject playerController = GameObject.Find("PlayerStatsController");
            PlayerStatsController controller = (PlayerStatsController)playerController.GetComponent(typeof(PlayerStatsController));
            controller.changeHealth(-10);
        }
    }
}
