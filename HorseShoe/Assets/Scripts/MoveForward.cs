using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveForward : MonoBehaviour
{
    public float speed = 3.5f;
    public int rotationSpeed = 1000;

    public bool rotationOn;
    public bool clockWise;

    public SpawnManager sm;
    public GameManagerGamePlay gm;

    void Awake()
    {
        sm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SpawnManager>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerGamePlay>();
    }
   

    void Start()
    {
      
        //deciding wheter if target will rotate at clockwise or counterclockwise.
        int clockWiser = Random.Range(0, 2);
        if (clockWiser == 0) 
        {
            clockWise = false;
        }
        else
        {
            clockWise = true;
        }


        if(sm.targetnumber > 10)
        {
            int rotationDecider = Random.Range(0, 2);

            if (rotationDecider == 1)
            {
                rotationOn = true;
            }
            else
            {
                rotationOn = false;
            }
        }
        else
        {
            rotationOn = false;
        }

    }


    void Update()
    {
        //transform.Translate(-Vector3.forward * speed * Time.deltaTime,Space.World); // constant forward movement along -z axis.

        if (transform.position.z < -10) // destroy out of bounds.
        {
            Destroy(gameObject);
        }


        if (rotationOn == true)
        {
            if (clockWise == false)
            {
                transform.Translate(-Vector3.forward * speed * Time.deltaTime * 0.5f, Space.World); // constant forward movement along -z axis.
                transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);

            }
            else if (clockWise == true)
            {
                transform.Translate(-Vector3.forward * speed * Time.deltaTime * 0.5f, Space.World); // constant forward movement along -z axis.
                transform.Rotate(-Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
            }
            
        }
        else if ( rotationOn == false)
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime, Space.World); // constant forward movement along -z axis.
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "GameOver")
        {
            gm.GameOver();

        }
    }


}
    
