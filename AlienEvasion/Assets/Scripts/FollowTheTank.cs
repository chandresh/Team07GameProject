using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to make the camera follow the tank
public class FollowTheTank : MonoBehaviour
{

    [SerializeField]
    Transform tankTransform;

    private Vector3 cameraOffset;

    void Start()
    {
        // Store the original difference between camera and tank positions
        cameraOffset = transform.position - tankTransform.position;
    }

    void Update()
    {
        // Set the camera position so that the camera follows the tank
        transform.position = tankTransform.position + cameraOffset;
    }
}
