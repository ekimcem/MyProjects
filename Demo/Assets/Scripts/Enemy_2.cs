using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    Vector3 pointA = new Vector3(-3, -1.9f, 0);
    Vector3 pointB = new Vector3(-3, 1.5f, 0);
   private  float speed = 1;
    private float t;
    

    // Start is called before the first frame update
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * speed;

        transform.position = Vector3.Lerp(pointA, pointB, t);
        if (t >= 1)
        {
            var b = pointB;
            var a = pointA;
            pointA = b;
            pointB = a;
            t = 0;
        }
    }
}
