using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheTank : MonoBehaviour
{

    [SerializeField]
    Transform tankTransform;

    private Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        // Store the original difference between camera and tank positions
        cameraOffset = transform.position - tankTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Set the camera position so that the camera follows the tank
        transform.position = tankTransform.position + cameraOffset;
    }
}
