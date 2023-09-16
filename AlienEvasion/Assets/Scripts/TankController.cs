using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    // Reference to the instructions information panel
    [SerializeField] GameObject instructionImage;
    // Variable to reference the Rigidbody of the tank
    Rigidbody2D tankRb;

    // Variable to keep track of the total distance traveled by the tank
    private float totalDistanceTraveled = 0f;

    // Convertion factor from unity units to kilometers
    private float unityToKilometers = 0.01f;

    // Adjust the center of mass of the tank
    [SerializeField] float centerOfMassX = 1.5f;

    // Rigidbodies of the three tires and the body

    [SerializeField] Rigidbody2D tire1Rb, tire2Rb, tire3Rb;

    [SerializeField] float tankSpeed = 200;

    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] GameManager gameManager;

    private float tankMovement;

    private AudioManager am;

    void Start()
    {
        // This code makes sure the center of mass of the tank is slightly on left
        // This makes sure that the tank does not fall down in the front because of long barrel
        tankRb = GetComponent<Rigidbody2D>();
        tankRb.centerOfMass -= new Vector2(centerOfMassX, 0);
        FreezeTankMotion();
        am = FindObjectOfType<AudioManager>();
    }

    // If the tank colides with an alien, destroy the alien and reduce the health of the tank
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            PlayerEventsManager.PlayerGotHit(-10);
        }
    }

    void FreezeTankMotion()
    {
        tire1Rb.freezeRotation = true;
        tire2Rb.freezeRotation = true;
        tire3Rb.freezeRotation = true;
    }

    void HideInstructionPanel()
    {
        // Hide the instruction panel
        instructionImage.SetActive(false);
    }

    void UnFreezeTankMotion()
    {
        tire1Rb.freezeRotation = false;
        tire2Rb.freezeRotation = false;
        tire3Rb.freezeRotation = false;
    }

    void Update()
    {
        // Get the value of Horizontal movement
        // Minus it as we want the tires to rotate opposite of it
        tankMovement = -Input.GetAxis("Horizontal");
        if (Math.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            if (!am.isPlaying("tank-move")) am.Play("tank-move");
        }
        else
        {
            if (am.isPlaying("tank-move")) am.Stop("tank-move");
        }
    }

    private void FixedUpdate()
    {
        // Add Torque to all the tires and car body
        float tankTorque = tankMovement * tankSpeed * Time.fixedDeltaTime;

        // The player has started moving the tank, unfreeze the tank motion
        // Also hide the instruction panel
        if (tankTorque != 0)
        {
            // Hide the instruction panel after half second
            Invoke("HideInstructionPanel", 0.5f);

            // Unfreeze the tank motion
            UnFreezeTankMotion();
        }

        tire1Rb.AddTorque(tankTorque);
        tire2Rb.AddTorque(tankTorque);
        tire3Rb.AddTorque(tankTorque);
        tankRb.AddTorque(tankTorque);

        SetTotalDistanceTraveled();
        GameManager.TotalDistanceTraveled = GetTotalDistanceTraveled();
    }
    public void SetTotalDistanceTraveled()
    {
        float horizontalVelocity = tankRb.velocity.x;
        float distanceThisFrame = horizontalVelocity * Time.fixedDeltaTime * unityToKilometers;
        // If the tank is moving forward update the distance
        if (horizontalVelocity > 0)
        {
            totalDistanceTraveled += Mathf.Abs(distanceThisFrame);
        }
        // If the tank is going backwards subtract the distance
        else if (horizontalVelocity < 0)
        {
            totalDistanceTraveled -= Mathf.Abs(distanceThisFrame);

            // If the distance goes in negative sett to zero
            if (totalDistanceTraveled < 0)
            {
                totalDistanceTraveled = 0;
            }
        }
    }

    public float GetTotalDistanceTraveled()
    {
        return (float)Math.Round(totalDistanceTraveled, 1);
    }

    private void OnEnable()
    {
        AlienEventsManager.OnAlienGotHit += Celebrate;
        GameManager.OnLevelChanged += TestLevelChange;
    }

    private void OnDisable()
    {
        AlienEventsManager.OnAlienGotHit -= Celebrate;
        GameManager.OnLevelChanged -= TestLevelChange;
    }

    void Celebrate()
    {
        particleSystem.Play();
    }

    void TestLevelChange(int level)
    {
        Debug.Log("Level changed to " + level);
        Debug.Log("Total distance traveled " + GetTotalDistanceTraveled());
    }
}
