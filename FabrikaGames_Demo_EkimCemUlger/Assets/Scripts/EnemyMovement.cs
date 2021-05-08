using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{

    private Rigidbody enemyRb;
    private GameObject player;
    public float speed;
    public float turnForce;
    private float strength = 5.0f;
    bool hasPowerUp = false;
    public GameManagerGameplay gmg;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }


    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        GameObject gm = GameObject.Find("GameManager");
        gmg = gm.GetComponent<GameManagerGameplay>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 lookDirection = (player.transform.position - transform.position);

         enemyRb.AddForce(lookDirection.normalized * speed);

         var forward = transform.forward;
         float angleToTarget = Vector3.Angle(forward, lookDirection);
        Vector3 turnAxis = Vector3.Cross(forward, lookDirection);
        enemyRb.AddTorque(turnAxis * angleToTarget * turnForce);

      

    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Water"))
        {
            gmg.win = true;
        }

    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * strength, ForceMode.Impulse);
            hasPowerUp = false;
        }
    }
}
