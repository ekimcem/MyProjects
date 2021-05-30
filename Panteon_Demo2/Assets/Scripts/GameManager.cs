using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region variables
    private PlayerController pc;
    public GameObject PlayerSpawnPoint;
    public GameObject playerPrefab;
    public GameObject wall;
    public GameObject enemyPrefab;
    private GameObject[] liveEnemies;
    private List<GameObject> enemies = new List<GameObject>();
    public ArrayList rank = new ArrayList();
    public Text position;
    string playerRank;
    public GameObject GameOverPanel;
    public GameObject TextScore;
    bool   gameStart=false;
    public GameObject PausePanel;
    public GameObject[] spawnPoints = new GameObject[10];
    public GameObject Pie;
    public GameObject player;
  
   

    #endregion


    void Awake()
    {
        InstantiateEnemies();
        player = GameObject.FindGameObjectWithTag("Player");
        Time.timeScale = 0;
    }
    void Start()
    {
       
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 0 && !gameStart)
        {
            Time.timeScale = 1;
            gameStart = true;
        }


    }
    void FixedUpdate()
    {
        
     
        RankingPlayers();
        if (pc.finish == true)
        {
           
            TextScore.SetActive(false);
            StartCoroutine("CreatePaintingWall");
        }      
    }

 

    private void RankingPlayers()
    {
        liveEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < liveEnemies.Length; i++)
        {
            rank.Add(liveEnemies[i].transform.position.z);
        }
        rank.Add(GameObject.FindGameObjectWithTag("Player").transform.position.z); 
        rank.Sort();
        rank.Reverse();
        playerRank = (1 + rank.IndexOf(GameObject.FindGameObjectWithTag("Player").transform.position.z)).ToString();
        position.text = (playerRank + " /11");
        rank.Clear();
    }
    public void InstantiateSingleEnemy()
    {

        int z = Random.Range(0, 10);

        Instantiate(enemyPrefab, spawnPoints[z].transform.position, transform.rotation);
    }
    private void InstantiateEnemies()
    {
        for (int i = 0; i < 10; i++)
        {
            
            enemies.Add(Instantiate(enemyPrefab,spawnPoints[i].transform.position, transform.rotation));

        }
    }
    IEnumerator CreatePaintingWall()
    {
        yield return new WaitForSeconds(1.5f);

            wall.SetActive(true);
            Pie.SetActive(true);

    }
    public  void ReloadtheGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);

    }
    public void ResumeButton()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
}
