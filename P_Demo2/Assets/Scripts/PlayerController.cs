using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region
    float p_Speed = 0.85f;
    private CameraShake cameraShake;
    public  CameraFollowPlayer cameraFollowPlayer;
  
    private GameManager gm;
   

    Rigidbody p_RigidBody;

    private Vector3 lastPos;
    public bool isGround = true;
    public bool gameOver=false;
    public bool finish = false;
    

    Animator playerAnim;
    #endregion
    void Start()
    {
        
        cameraFollowPlayer = GameObject.FindGameObjectWithTag("CameraHolder").GetComponent<CameraFollowPlayer>();
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        playerAnim = GetComponent<Animator>();
        p_RigidBody = GetComponent<Rigidbody>();

    }
    void FixedUpdate()
    {
        if (gameOver)
        {
            Invoke("SpawnToSpawnPoint",0.5f);
        }
        if(transform.position.x >= 0.41f || transform.position.x <= -0.41f)
        {
            isGround = false;
        }
    }
    void Update()

    {  
       if (!gameOver&&!finish) {
            if (Input.GetMouseButtonDown(0))
            {
                lastPos.x = Input.mousePosition.x;
                lastPos.y = Input.mousePosition.y;
            }
            else if (Input.GetMouseButton(0) && isGround)
            {
                playerAnim.SetBool("isRunning", true);
                float xDirection = Input.mousePosition.x - lastPos.x;
                float zDirection = Input.mousePosition.y - lastPos.y;

                Vector3 aim = new Vector3(xDirection, 0, zDirection).normalized;
                p_RigidBody.velocity = aim * p_Speed;

                transform.rotation = Quaternion.LookRotation(aim);
            }
            else { playerAnim.SetBool("isRunning", false); }
        }
        else if (finish) {

            cameraFollowPlayer.paintingAim = true;
        }
      

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {

            playerAnim.SetBool("isDead", true);


            gameOver = true;

            StartCoroutine(cameraShake.Shake(0.08f, 0.1f));

        }
        else if (collision.gameObject.CompareTag("Water"))
        {

            playerAnim.SetBool("isDead", true);
            gameOver = true; }

       


  else if (collision.gameObject.CompareTag("FinishObject"))
        {
            finish = true;
            playerAnim.SetBool("isFinish", true);
        }
     else if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }         
    }
  

    public void  SpawnToSpawnPoint() {
       
        gameOver = false;
        playerAnim.SetBool("isDead", false);
        transform.localPosition = gm.PlayerSpawnPoint.transform.position;
        
     

    }

   
}
