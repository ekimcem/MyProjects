using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationSpeed = 100f;
        
        
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
      

    }
    
}
