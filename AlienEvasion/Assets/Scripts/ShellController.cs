using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{

    // Destroy the shell when it leaves the screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Destroy the shell when it hits something
    void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy the shell if other object's tag is Ground
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            Debug.Log("Shell hit " + other.gameObject.name);
        }
    }
}
