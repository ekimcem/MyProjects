using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    float rotationSpeed = 100;
   
    Rigidbody rb;
   
    void Start()
    {
      
    }

    
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
        

        
    }
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(-33, 0, 0);
            Debug.Log("Force eklendi");
        }
    }





}
