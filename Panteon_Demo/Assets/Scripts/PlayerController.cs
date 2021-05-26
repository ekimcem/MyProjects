using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float p_Speed = 0.85f;
    public CameraShake cameraShake;
    public CameraFollowPlayer cameraFollowPlayer;
    public GameObject restartButton;

    Rigidbody p_RigidBody;

    Vector3 lastPos;
    bool isGround;
    bool gameOver=false;
    public bool finish = false;

    Animator playerAnim;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        p_RigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver&&!finish) {
            if (Input.GetMouseButtonDown(0))
            {
                lastPos.x = Input.mousePosition.x;
                lastPos.y = Input.mousePosition.y;
            }
            else if (Input.GetMouseButton(0) && (isGround))
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
        else if (gameOver)
        {
          
            restartButton.SetActive(true);
        }

    }

   

    private void OnCollisionEnter(Collision collision)
    {
  if (collision.gameObject.CompareTag("Obstacle"))
        {
           
            playerAnim.SetBool("isDead",true);
            gameOver = true;
            StartCoroutine(cameraShake.Shake(0.08f, 0.1f));
        }
  else if (collision.gameObject.CompareTag("Water"))
        {
           
            playerAnim.SetBool("isDead", true);
            gameOver = true;
        }
  else if (collision.gameObject.CompareTag("FinishObject"))
        {
            finish = true;
            playerAnim.SetBool("isFinish", true);
        }
              
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground")){ isGround = false; }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") ) { isGround = true;  }
        if (collision.gameObject.CompareTag("RotatingPlatform")) { isGround = true; }
    }

}
