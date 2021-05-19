using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject targetPrefab;

    private float startDelay = 2;
    public float spawnInterval = 2.5f;

  

    public float[] spawnPoint;
    

    public float spawnPosZ = 10;
    public float spawnPosY = 0.25f;
    public float targetAngle = 30;

    public int targetnumber;

    public MoveForward mf;


    //Awake is called before the start function
    void Awake()
    {
        targetnumber = 0;
    }
  

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomTarget", startDelay, spawnInterval);

        Debug.Log("First spawninterval is" + spawnInterval);
        Debug.Log("First speed is" + mf.speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void SpawnRandomTarget()
    {

        int targetIndex = Random.Range(0, spawnPoint.Length);

        Vector3 spawnPos = new Vector3(spawnPoint[targetIndex], spawnPosY, spawnPosZ);

        if(targetIndex == 0)
        {
            Instantiate(targetPrefab, spawnPos, Quaternion.Euler(90, -targetAngle, 0));
            targetnumber++;
        }
        else
        {
            Instantiate(targetPrefab, spawnPos,Quaternion.Euler(90,targetAngle,0));
            targetnumber++;
        }

        SpawnIntervalAndSpeedDetermine();


    }

    private void SpawnIntervalAndSpeedDetermine()
    {
        if(targetnumber %10 == 0)
        {
            spawnInterval *= 0.9f; //set the spawn interval when target number reaches 10 or multiples of 10
            Debug.Log("Updated spawninterval is" + spawnInterval);

            mf.speed *= 1.1f; //set the new speed when targetnumber reaches 10 or multiples of 10
            Debug.Log("Updated speed is" + mf.speed);

        }
    }

    
 
}
