using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kure_hareket : MonoBehaviour
{
    public float kure_hizi;

    Vector3 yon;

    public zemin_olusturma zeminolustur;

    public AudioSource audioSource;
    public AudioClip audioClip;
    static int  toplanan_odul_sayisi = 0;

    //Canvas canvas;

    public Text uiText;



  
    void Start()
    {
        yon = Vector3.back;
    }





    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if ( yon.x == 0)
            {
                yon = Vector3.left;
            }
            else 
            {
                yon = Vector3.back;
            }
        }
    }


    private void FixedUpdate()
    {
        Vector3 hareket = yon * Time.deltaTime * kure_hizi;
        transform.position += hareket;
    }

    private void OnCollisionExit(Collision collision)


    {
        
        if(collision.gameObject.tag == "zemin")
        {
            StartCoroutine(Yoket(collision.gameObject));

            zeminolustur.zemin_olustur();

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "odul")
        {
            Destroy(collision.gameObject);
            zeminolustur.i = 1;
            audioSource.PlayOneShot(audioClip,  4.0f);

            toplanan_odul_sayisi++;

            uiText.text = "Toplanan Odul : " + toplanan_odul_sayisi.ToString();
          
        }
    }


    IEnumerator Yoket( GameObject yokedilecek)
    {
        yield return new WaitForSeconds(0.5f);
        yokedilecek.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(2.0f);
        Destroy(yokedilecek);
    }
   
}
