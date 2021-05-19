using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class kamera_takip : MonoBehaviour
{
   public GameObject gameover_image;
    public Transform ball;
    Vector3 fark;


    // Start is called before the first frame update
    void Start()
    {
        fark = transform.position - ball.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if(ball.position.y <= -1)
        {
            transform.position = transform.position;
            gameover_image.SetActive(true);

        }else 
        { 
            transform.position = ball.position + fark;
        }

       
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
