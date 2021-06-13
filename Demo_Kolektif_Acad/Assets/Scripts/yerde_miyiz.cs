using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yerde_miyiz : MonoBehaviour
{
    public LayerMask Layer;
    public LayerMask Jump;
    public bool yerde_misin;
    public bool trambolinde_misin;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {


        RaycastHit2D carpis = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, Layer);

        if (carpis.collider != null)
        { 
            yerde_misin = true;

        }
        else
        {
           
            yerde_misin = false;


        }


        if (Input.GetKeyDown(KeyCode.Space) && (yerde_misin == true))
        {
            rb.velocity += new Vector2(0, 5f);
        }






        RaycastHit2D zip = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, Jump);

        if (zip.collider != null)
        {
            trambolinde_misin = true;

        }
        else
        {

            trambolinde_misin = false;


        }


        if (trambolinde_misin == true)
        {
            rb.velocity+= new Vector2(0,5f);
        }


    }
}
