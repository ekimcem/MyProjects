using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonDestroy : MonoBehaviour
{
    public Vector3 SpawnPos = new Vector3(0, 0.5f, -5.4f);

    public GameObject playerBallPrefab;

    public GameManagerGamePlay gm;



    // Start is called before the first frame update
    

    // Update is called once per frame
  
    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerGamePlay>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            gm.score++;
            top_cagir();
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
    }

    public void top_cagir()

    {
        
        Instantiate(playerBallPrefab, SpawnPos, Quaternion.Euler(0, 0, 0));
        gameObject.GetComponent<CollisonDestroy>();
        gameObject.GetComponent<PlayerController>();
        

    }

}
