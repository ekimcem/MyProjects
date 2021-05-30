using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingStick : MonoBehaviour
{
    Vector3 hitDirection;
    Vector3 diff_;
    public GameObject rotator;
    public float smashForce=400;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        diff_ =(collision.gameObject.transform.position - rotator.transform.position);
        hitDirection = diff_.normalized;
        collision.rigidbody.AddForce(hitDirection*smashForce,ForceMode.Impulse);
    }
}
