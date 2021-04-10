using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public Animator benim_animasyoncu;
    
    public float hizkatsayisi = 5.0f;
    public  int altinsayisi = 0;
    public int health = 3;
    public Text score;
    public Text can;
    public GameObject oyun_sonu_panel;
    public AudioSource altin_sesi;

    

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float yatay = Input.GetAxis("Horizontal");
        
        transform.position += new Vector3(yatay * Time.deltaTime * hizkatsayisi, 0, 0);

     bool kosuyor_muyuz = false;
        if (yatay != 0)
        {
            kosuyor_muyuz = true;
            benim_animasyoncu.speed = Mathf.Abs(yatay);
        }
        benim_animasyoncu.SetBool("kosuyor_mu", kosuyor_muyuz);
        if (yatay > 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f,0.5f);
        }

        else if (yatay < 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        } 

    }

    public void OnTriggerEnter2D(Collider2D Carpisilan_nesne)
    {

        if (Carpisilan_nesne.tag == "altinlar")
        {
            Debug.Log("Altin toplandı");
            altin_sesi.Play();
            altinsayisi++;
            score.text = altinsayisi.ToString();
            Destroy(Carpisilan_nesne.gameObject);
        }

        
    }
    public void OnCollisionEnter2D(Collision2D dusman)
    {
        if (dusman.gameObject.tag == "enemy")
        {
            health--;
            
            if (health == 0) 
            {
                Destroy(gameObject);
                oyun_sonu_panel.SetActive(true);
            }
            can.text = health.ToString();
        }
    }


    

}
