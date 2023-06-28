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

    // Get the shell prefab from the inspector
    [SerializeField] private GameObject shellPrefab;

    // Get the tank game object from the inspector
    [SerializeField] private GameObject tank;

    // Shell Barrel position offset
    [SerializeField] private Vector3 shellBarrelPositionOffset = new Vector3(1.2f, 0, 0);

    [SerializeField] private float shellSpeed = 40f;

    // A timer for the delay between shots
    private float fireDelay = 0.5f;
    private float nextFireTime = 0;



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

        // If the player is holding the Fire1 button (space by default), fire the shell
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireDelay;
            Fire(upAngle);
        }

    }

    void Fire(float angle)
    {
        // Fire the shell

        // Instantiate the shell at the barrel's position plus some offset
        GameObject shell = Instantiate(shellPrefab, transform.position + shellBarrelPositionOffset, Quaternion.identity);

        // Calculate the direction to apply force to the shell
        Vector2 shellDirection = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

        // Get the shell's Rigidbody2D component
        Rigidbody2D shellRb = shell.GetComponent<Rigidbody2D>();

        // Set the shell's velocity and fire it
        shellRb.velocity = tank.transform.right * shellSpeed;
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
