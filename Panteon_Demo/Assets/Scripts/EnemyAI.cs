using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    #region variables

    Rigidbody enemyRb;

    Animator playerAnim;

    bool finish = false;
    bool isGround;
    bool isDead = false;

    public GameManager gm;

    private float enemySpeed= 1.35f;
    private float angle = 100;
    private float rayRange = 0.2f;
    private float xBound=0.406f;
 
    private int numberofRays = 180;

#endregion
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody>();
    }

    void Update()
    {  
        DestroyOutOfBounds();
        EnemyMovement();
    }

    private void DestroyOutOfBounds()
    {
        if (transform.position.x > xBound || transform.position.x < -xBound)
        {
            Invoke("GameOver", 2f);
        }
    }

    private void EnemyMovement()
    {
        if (!isDead&&!finish)
        {
            if (isGround)
            {
                playerAnim.SetBool("isRunning", true);
            }

            var deltaPosition = Vector3.zero;
            for (int i = 0; i < numberofRays; ++i)
            {
                var rotation = this.transform.rotation;
                var rotationMod = Quaternion.AngleAxis((i / ((float)numberofRays - 1)) * angle * 2 - angle, this.transform.up);
                var direction = rotation * rotationMod * Vector3.forward;

                var ray = new Ray(this.transform.position + new Vector3(0, 0.025f, 0), direction);
                RaycastHit hitInfo;

                Debug.DrawRay(this.transform.position + new Vector3(0, 0.025f, 0), direction);


                if (Physics.Raycast(ray, out hitInfo, rayRange))
                {
                    deltaPosition -= (1.0f / numberofRays) * enemySpeed * direction;


                }
                else
                {
                    deltaPosition += (1.0f / numberofRays) * enemySpeed * direction;
                }
            }
            this.transform.position += deltaPosition * Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAnim.SetBool("isDead", true);
            isDead = true;
            Invoke("GameOver", 2f);


        }
        else if (collision.gameObject.CompareTag("FinishObject"))
        {
            finish = true;
            playerAnim.SetBool("isFinish", true);
        }
        else if (collision.gameObject.CompareTag("RotatingPlatform"))

        {
            enemyRb.isKinematic = true;

        } 
        else if (collision.gameObject.CompareTag("Ground"))

        {
           

        }
        else if (collision.gameObject.CompareTag("Water"))

        {
            playerAnim.SetBool("isDead", true);
            isDead = true;
            Invoke("GameOver", 2f);
        }
         
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) { isGround = true; }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("RotatingPlatform")) { enemyRb.isKinematic = false; }
        if (collision.gameObject.CompareTag("Ground")) { isGround = false;  }
        

    }

  IEnumerator GameOver()
    {
        
        gm.InstantiateSingleEnemy();
        Destroy(gameObject);
        return null;
    }
    
   
    /*private void OnDrawGizmos()
    {
        for ( int i= 0; i< numberofRays; ++i)
        {
            var rotation = this.transform.rotation;
            var rotationMod= Quaternion.AngleAxis((i / ((float)numberofRays - 1)) * angle * 2 - angle, this.transform.up);
            var direction = rotation * rotationMod *Vector3.forward;
            Gizmos.DrawRay(this.transform.position+new Vector3(0,0.02f,0), direction);
        }
    }*/

}
