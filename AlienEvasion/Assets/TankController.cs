using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    Rigidbody2D tankRb;

    // Start is called before the first frame update
    void Start()
    {
        tankRb = GetComponent<Rigidbody2D>();
        tankRb.centerOfMass -= new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
