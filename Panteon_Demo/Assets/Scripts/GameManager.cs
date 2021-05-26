using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController pc;
    public GameObject wall;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject enemyPrefab;
    public GameObject[] liveEnemies;
    public ArrayList rank = new ArrayList();
    public Text position;
    string playerRank;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        InstantiateEnemies();
    }

    

    // Update is called once per frame
    void Update()
    {
            
            
        liveEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i< liveEnemies.Length; i++)
        {
            rank.Add(GameObject.FindGameObjectWithTag("Player").transform.position.z);
            rank.Add(liveEnemies[i].transform.position.z);
            rank.Sort();
            playerRank = (11-rank.IndexOf(GameObject.FindGameObjectWithTag("Player").transform.position.z)).ToString();
            Debug.Log(playerRank);
            position.text = (playerRank + " /11");
        }
        rank.Clear();

        












        if (Input.GetMouseButton(0))
        {
            Time.timeScale = 1;
        }
        if (pc.finish == true)
        {
            Invoke("CreatePaintingWall", 1.5f);
        }


        
    }
    private Vector3 RandomSpawnVectorGenerator()
    {
        float x = Random.Range(-0.4f, 0.4f);
        float z = Random.Range(-0.5f, -1.5f);
        Vector3 spawnPos = new Vector3(x, 0.037f, z);
        return spawnPos;
    }
    public void InstantiateSingleEnemy()
    {
        
        Instantiate(enemyPrefab, RandomSpawnVectorGenerator(), transform.rotation);
    }

    private void InstantiateEnemies()
    {
        for (int i = 0; i < 10; i++)
        {

            enemies.Add(Instantiate(enemyPrefab, RandomSpawnVectorGenerator(), transform.rotation) as GameObject);

        }
    }
    IEnumerator CreatePaintingWall()
    {
        
            wall.SetActive(true);
        
        return null;
    }

    public  void ReloadtheGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
