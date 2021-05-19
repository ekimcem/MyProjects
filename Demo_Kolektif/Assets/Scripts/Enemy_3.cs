using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_3 : MonoBehaviour
{
    Vector3 pointA = new Vector3(9, -2.22f, 0);
    Vector3 pointB = new Vector3(4, -2.22f, 0);
   private  float speed = 0.3f;
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


    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
