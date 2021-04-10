using System;
using System.IO.MemoryMappedFiles;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private GameObject particleBlue;
    [SerializeField] private GameObject particleRed;
    [SerializeField] private GameObject particleYellow;
    [SerializeField] private GameObject groundForward;
    private GameObject _playerTwo;

    private SkinnedMeshRenderer skinMesh;
    private Rigidbody rb;
    private Animator anim;

    private float screenWidght;
    private float screenHeight;
    private Vector3 mousePos;

    void Start()
    {
        //_confetti.SetActive(false);
        _playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");
        skinMesh = transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>();
        rb = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        screenHeight = Screen.height;
        screenWidght = Screen.width;
    }
    private void Update()
    {
        mousePos = Input.mousePosition;
        //Debug.Log(" mousePos " + mousePos.x);
        if (GameManager.gameStart == true)
        {
            PlayerMove();
        }
    }
    private void PlayerMove()
    {
        rb.velocity = Vector3.forward * playerSpeed * 0.8f;
        anim.SetBool("isRun",true);
        if (Input.GetMouseButton(0) && mousePos.x > 545)
        {
            rb.velocity = new Vector3(0.9f * turnSpeed, 0, 1f * playerSpeed * 0.8f);
        }
        else if (Input.GetMouseButton(0) && mousePos.x < 440)
        {
            rb.velocity = new Vector3(-0.9f * turnSpeed, 0, 1f * playerSpeed * 0.8f );
        }
        //else
        //{
        //    rb.velocity = Vector3.forward * playerSpeed * 0.8f;
        //}
        // else if (mousePos.x > 400 && mousePos.x < 600 )
        // {
        //     rb.velocity = new Vector3(0,0,3f * playerSpeed);
        // }   
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Win"))
        {
            _playerTwo.gameObject.transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material = skinMesh.material;
            GameManager.instance.IsDanceSound();
            anim.SetBool("isDance", true);
        }
        else if(col.gameObject.CompareTag("Finish"))
        {
            transform.position = _playerTwo.transform.position - Vector3.right * 0.4f;
            //_playerTwo.transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material = skinMesh.material;
            //_playerTwo.transform.GetChild(0).GetComponent<Animator>().SetBool("isDance",true);
            //anim.SetBool("isDance", true);
            //GameManager.instance.IsDance();
            //gameObject.GetComponent<PlayerController>().enabled = false;        
        }
        else if (col.gameObject.name == "Player")
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("BlueBall"))
        {
            skinMesh.material = other.gameObject.GetComponent<MeshRenderer>().material;
            gameObject.tag = "BluePlayer";
            groundForward.tag = "BlueGround";
            groundForward.GetComponent<MeshRenderer>().enabled = true;
            groundForward.GetComponent<MeshRenderer>().material = skinMesh.material;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("RedBall"))
        {
            skinMesh.material = other.gameObject.GetComponent<MeshRenderer>().material;
            gameObject.tag = "RedPlayer";
            groundForward.tag = "RedGround";
            groundForward.GetComponent<MeshRenderer>().enabled = true;
            groundForward.GetComponent<MeshRenderer>().material = skinMesh.material;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("YellowBall"))
        {
            skinMesh.material = other.gameObject.GetComponent<MeshRenderer>().material;
            gameObject.tag = "YellowPlayer";
            groundForward.tag = "YellowGround";
            groundForward.GetComponent<MeshRenderer>().enabled = true;
            groundForward.GetComponent<MeshRenderer>().material = skinMesh.material;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.GetComponent<MeshRenderer>().material.color != skinMesh.material.color && other.gameObject.name != "PlayerTwo")
        {
            if (gameObject.CompareTag("BluePlayer"))
            {
              Instantiate(particleBlue,transform.position,transform.rotation);
              Destroy(gameObject,0.2f);
            }
            else if (gameObject.CompareTag("RedPlayer"))
            {
                Instantiate(particleRed,transform.position,transform.rotation);
                Destroy(gameObject, 0.2f);
            }
            else if (gameObject.CompareTag("YellowPlayer"))
            {
                Instantiate(particleYellow, transform.position, transform.rotation);
                Destroy(gameObject, 0.2f);
            }
            else if (gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.CompareTag("BlueGround"))
        {
            playerSpeed = 8f;
        }
        else if (other.gameObject.CompareTag("RedGround"))
        {
            playerSpeed = 8f;
        }
        else if (other.gameObject.CompareTag("YellowGround"))
        {
            playerSpeed = 8f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BlueGround"))
        {
            playerSpeed = 4f;
        }
        else if (other.gameObject.CompareTag("RedGround"))
        {
            playerSpeed = 4f;
        }
        else if (other.gameObject.CompareTag("YellowGround"))
        {
            playerSpeed = 4f;
        }
    }

}
