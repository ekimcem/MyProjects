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

    private float enemySpeed= 1.3f;
    private float angle = 100;
    private float rayRange = 0.2f;
   
    private GameObject finishObject;
    private int numberofRays = 120;

#endregion

    void Awake()
    {
        finishObject = GameObject.FindGameObjectWithTag("FinishObject");
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
      
        playerAnim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {  
    
        EnemyMovement();
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
                    deltaPosition -= (1f / numberofRays) * enemySpeed * direction;


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
        if (collision.gameObject.CompareTag("Obstacle")||collision.gameObject.CompareTag("Water"))
        {
            playerAnim.SetBool("isDead", true);
            isDead = true;
            Invoke("GameOver", 1.5f);


        }
        else if (collision.gameObject.CompareTag("FinishObject"))
        {
            finish = true;
            playerAnim.SetBool("isFinish", true);
            
            enemyRb.AddForce(Vector3.forward *39,ForceMode.Impulse);
        }
        else if (collision.gameObject.CompareTag("RotatingPlatform"))

        {
            enemyRb.isKinematic = true;

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
  

}
