using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    float rotationSpeed = 900;
    Rigidbody rb;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

       
        rb.AddTorque(transform.forward * rotationSpeed);
        
    }
}
