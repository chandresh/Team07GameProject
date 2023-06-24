using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    // Variable to reference the Rigidbody of the tank
    Rigidbody2D tankRb;

    // Rigidbodies of the three tires and the body
    [SerializeField]
    Rigidbody2D tire1Rb, tire2Rb, tire3Rb;

    [SerializeField]
    float tankSpeed = 20;

    private float tankMovement;

    void Start()
    {
        // This code makes sure the center of mass of the tank is slightly on left
        // This makes sure that the tank does not fall down in the front because of long barrel
        tankRb = GetComponent<Rigidbody2D>();
        tankRb.centerOfMass -= new Vector2(1, 0);

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
        tire1Rb.AddTorque(tankTorque);
        tire2Rb.AddTorque(tankTorque);
        tire3Rb.AddTorque(tankTorque);
        tankRb.AddTorque(tankTorque);
    }
}
