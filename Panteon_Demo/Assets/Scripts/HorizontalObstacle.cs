using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(startPos.x + 0.7f, startPos.y, startPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        var a = startPos;
        var b = endPos;
        t += Time.deltaTime;

        transform.position = Vector3.Lerp(startPos, endPos, t);

        if (t >= 1)
        {
            endPos = a;
            startPos = b;
            t = 0f;
        }
    }
}
