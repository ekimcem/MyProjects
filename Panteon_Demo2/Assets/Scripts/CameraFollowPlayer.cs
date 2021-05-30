using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    GameObject player;
    public bool paintingAim=false;
    PlayerController pc;
   
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

   
    void FixedUpdate()
    {
       
            transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z - 0.8f);
      
        
        if (paintingAim)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(3, transform.rotation.y, transform.rotation.z);

        }  
    }
}
