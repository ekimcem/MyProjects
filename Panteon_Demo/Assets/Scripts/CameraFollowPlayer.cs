using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    GameObject player;
    public bool paintingAim=false;
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z-0.8f);

        if (paintingAim)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z-0.05f);
            transform.rotation = Quaternion.Euler(3, transform.rotation.y, transform.rotation.z);

        }
    }
}
