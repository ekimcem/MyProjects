using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    private float spawnRange = 8.0f;

    Vector3 enemySpawnPos = new Vector3(5, 0, 5);
  
   


    
    // Start is called before the first frame update
    void Start()
    {
  

        Instantiate(enemyPrefab, enemySpawnPos, Quaternion.Euler(0, 0, 0));
        InvokeRepeating("InstantiatePowerUp", 1, 5);

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiatePowerUp()
    {
        Instantiate(powerUpPrefab, GeneratePowerUpSpawnPosition(), Quaternion.Euler(0, 0, 0));
        
    }
    private Vector3 GeneratePowerUpSpawnPosition()
    {

        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0.75f, spawnPosY);
        return randomPos;
    }
}
