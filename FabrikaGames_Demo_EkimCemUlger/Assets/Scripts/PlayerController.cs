using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem hitParticle;

    public float speed = 250.0f;
    private float rotationSpeed =100.0f;
    private float wheelRotationSpeed = 200.0f;
    public float strength = 5.0f;

    public GameObject arrowsHorizontal;
    public GameObject arrowsVertical;
    public GameObject pauseButton;

    private Rigidbody playerRB;
    private Transform wheelTransform;
    private GameObject wheel;
    public GameObject lostPanel;
    public GameObject lostText;
    public GameObject winText;

    bool hasPowerUp;

    public CameraShake cameraShake;
    

   
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        wheel = GameObject.FindGameObjectWithTag("Wheel");
        wheelTransform = wheel.GetComponent<Transform>();
    }
    



    void FixedUpdate()
    {
        
        // Player Vertical Control
        float forwardInput = SimpleInput.GetAxis("Vertical");
        playerRB.AddForce(playerRB.transform.forward * speed * forwardInput);

        //Player Horizontal Control
        float horizontalInput = SimpleInput.GetAxis("Horizontal");
        if(forwardInput != 0) { 
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
       

        //Wheel Rotation
        if(horizontalInput != 0)
        {
           
            wheelTransform.Rotate(-Vector3.forward, horizontalInput * wheelRotationSpeed * Time.deltaTime);
            float angle = wheelTransform.localRotation.z;
          //  Debug.Log(angle);

            if (angle >= 0.75)
            {
                wheelTransform.localRotation = Quaternion.Euler(34.149f, wheelTransform.localRotation.y, 103);

            } else if (angle <=-0.75)
            {
                wheelTransform.localRotation = Quaternion.Euler(34.149f, wheelTransform.localRotation.y, -103);
            }
        } else

        {
            Quaternion currentRotation = wheelTransform.localRotation;
            Quaternion zeroRotation = Quaternion.Euler(34.149f,0, 0);
            wheelTransform.localRotation = Quaternion.RotateTowards(currentRotation, zeroRotation, Time.deltaTime*250);
        }
        
        
     
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            
            arrowsHorizontal.SetActive(false);
            arrowsVertical.SetActive(false);
            pauseButton.SetActive(false);
            lostPanel.SetActive(true);
            lostText.SetActive(true);
            winText.SetActive(false);
            Time.timeScale = 0f;
            
        }
        else if (other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
        }
  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")&& hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * strength, ForceMode.Impulse);

            HitEffects(collision);

        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            HitEffects(collision);
        }
    }

    private void HitEffects(Collision collision)
    {
        var contPoint = collision.contacts[0];
        Instantiate(hitParticle, contPoint.point, Quaternion.identity);
        hitParticle.Play();
        hasPowerUp = false;
        StartCoroutine(cameraShake.Shake(0.1f,0.2f));

    }



}
