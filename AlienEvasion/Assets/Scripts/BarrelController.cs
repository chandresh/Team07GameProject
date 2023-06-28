/*
This class controls the Barrel. It rotates and moves the barrel between two predefined positions based on the
player's input. When the player presses the up key (which corresponds to a positive vertical input), the barrel
rotates up and moves to the 'up' position. When the player presses the down key (which corresponds to a negative
vertical input), the barrel rotates down and moves back to its default position.
*/

using UnityEngine;

public class BarrelController : MonoBehaviour
{
    // Default and 'up' angle for the barrel
    private float defaultAngle;
    [SerializeField] private float upAngle = 30f;

    // Default and 'up' positions for the barrel
    private Vector3 defaultBarrelPosition, upBarrelPosition;

    // Offsets for the 'up' position
    [SerializeField] private Vector3 upBarrelPositionOffset = new Vector3(-0.3f, 0.8f, 0);

    private void Start()
    {
        // Store the initial angle of the barrel as the default
        defaultAngle = transform.localEulerAngles.z;

        // Store the initial position of the barrel as the default
        defaultBarrelPosition = transform.localPosition;

        // Calculate the 'up' position as a slight offset from the default
        upBarrelPosition = defaultBarrelPosition + upBarrelPositionOffset;
    }

    private void Update()
    {
        // Get the vertical input from the player (up/down arrow or W/S keys by default)
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0)
        {
            // If the player is pressing up, rotate the barrel up
            RotateUp();
        }
        else if (verticalInput < 0)
        {
            // If the player is pressing down, rotate the barrel down
            RotateDown();
        }

    }

    void RotateUp()
    {
        // Set the barrel's rotation to the 'up' angle
        transform.localEulerAngles = new Vector3(0, 0, upAngle);
        // Move the barrel a little bit up and to the left
        transform.localPosition = upBarrelPosition;
    }

    void RotateDown()
    {
        // Set the barrel's rotation to the default angle and position
        transform.localEulerAngles = new Vector3(0, 0, defaultAngle);
        transform.localPosition = defaultBarrelPosition;
    }

    void Rotate(float angle)
    {
        // Rotate the barrel about the X-axis by the specified angle, multiplied by the time since the last frame
        transform.Rotate(Vector3.right * angle * Time.deltaTime);
    }
}
