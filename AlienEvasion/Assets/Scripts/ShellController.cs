using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{

    private Rigidbody2D shellRb;
    [SerializeField] private float shellSpeed = 10f;

    private GameObject tank;

    private AudioManager am;

    private void Start()
    {
        am = FindObjectOfType<AudioManager>();
        shellRb = GetComponent<Rigidbody2D>();
        tank = GameObject.Find("Tank");
        float tankSpeed = tank.GetComponent<Rigidbody2D>().velocity.magnitude;
        shellSpeed = shellSpeed + tankSpeed;
        shellRb.velocity = transform.right * shellSpeed;
        am.Play("shell-shoot");
    }

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
            am.Play("explosion");
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyShip")
        {
            am.Play("explosion");
            AlienEventsManager.AlienIsHit();
            // Debug.Log("Shell hit " + other.gameObject.tag);
            Destroy(other.gameObject);
        }
    }
}
