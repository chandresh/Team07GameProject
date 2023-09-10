using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTheShell : MonoBehaviour
{

    // Get the shell prefab from the inspector
    [SerializeField] private GameObject shellPrefab;

    // A timer for the delay between shots
    private float fireDelay = 0.5f;
    private float nextFireTime = 0;

    [SerializeField] private Transform shootingPosition;

    private float baseFireDelay = 0.5f;
    private float modifiedFireDelay; // Add this variable

    private void Start()
    {
        modifiedFireDelay = baseFireDelay; // Initialize it with the base value
    }

    public void UpdateFireDelay(float newDelay)
    {
        modifiedFireDelay = newDelay;
    }


    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + modifiedFireDelay; // Use the modified fire delay
            Fire();
        }
    }

    void Fire()
    {
        // Instantiate the shell at the barrel's position plus some offset
        GameObject shell = Instantiate(shellPrefab, shootingPosition.position, transform.rotation);
    }
}
