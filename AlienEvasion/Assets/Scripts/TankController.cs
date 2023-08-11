using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

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

    void Start()
    {
        // This code makes sure the center of mass of the tank is slightly on left
        // This makes sure that the tank does not fall down in the front because of long barrel
        tankRb = GetComponent<Rigidbody2D>();
        tankRb.centerOfMass -= new Vector2(centerOfMassX, 0);
        FreezeTankMotion();
    }

    void FreezeTankMotion()
    {
        tire1Rb.freezeRotation = true;
        tire2Rb.freezeRotation = true;
        tire3Rb.freezeRotation = true;
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
    }

    private void FixedUpdate()
    {
        // Add Torque to all the tires and car body
        float tankTorque = tankMovement * tankSpeed * Time.fixedDeltaTime;


        if (tankTorque != 0)
        {
            UnFreezeTankMotion();
        }

        tire1Rb.AddTorque(tankTorque);
        tire2Rb.AddTorque(tankTorque);
        tire3Rb.AddTorque(tankTorque);
        tankRb.AddTorque(tankTorque);

        SetTotalDistanceTraveled();
        gameManager.TotalDistanceTraveled = GetTotalDistanceTraveled();
    }
    public void SetTotalDistanceTraveled()
    {
        float horizontalVelocity = tankRb.velocity.x;
        float distanceThisFrame = horizontalVelocity * Time.fixedDeltaTime * unityToKilometers;
        totalDistanceTraveled += Mathf.Abs(distanceThisFrame);
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
    }
}
