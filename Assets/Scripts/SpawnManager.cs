using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Variables
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public GameObject objectivePrefab;

    private float spawnRangeX = 170;
    private float spawnRangeCX = 100;
    private float spawnRangeZ = 130;
    private float spawnRangeCZ = 100;

    [SerializeField] private int enemyCount;
    [SerializeField] private int waveNumber;
    public int objectiveCount;



    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);

    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
      
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // Generate enemies in the scene
            Instantiate(enemyPrefab, GeneratesSpawnPositionEnemies(), enemyPrefab.transform.rotation);

        }

        if (enemiesToSpawn > 5)
        {
            enemiesToSpawn = 0;
        }


    }

    // Update is called once per frame
    void Update()
    {
        // find the enemy and objective object by your script
        enemyCount = FindObjectsOfType<Enemy>().Length;
        objectiveCount = FindObjectsOfType<Objective>().Length;

        // Manage the generation of more waves if the objective was collected   
        if (objectiveCount == 0)
        {

            Instantiate(powerUpPrefab, GeneratesSpawnPositionCollectables(), powerUpPrefab.transform.rotation);
            Instantiate(objectivePrefab, GeneratesSpawnPositionCollectables(), objectivePrefab.transform.rotation);
            waveNumber++;

            SpawnEnemyWave(waveNumber);

            // Increase enemy speed with each wave
            enemyPrefab.GetComponent<Enemy>().speed *= 1.2f;

            // Controls the number of enemies and their speed

            if (waveNumber >= 7 )
            {
                enemyCount = 0;
                waveNumber = 0;
               
            }
            if (enemyPrefab.GetComponent<Enemy>().speed >= 90)
            {
                enemyPrefab.GetComponent<Enemy>().speed = 30.0f;
            }


        }

    }

    private Vector3 GeneratesSpawnPositionEnemies()
    {
        // Generate random values between -300 and 300
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeZ);
        float spawnPosZ = Random.Range(-spawnRangeX, spawnRangeZ);
        float spawnPosY = 10;

        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        return randomPos;
    }

    private Vector3 GeneratesSpawnPositionCollectables()
    {
        // Generate random values between -200 and 200
        float spawnCPosX = Random.Range(-spawnRangeCX, spawnRangeCZ);
        float spawnCPosZ = Random.Range(-spawnRangeCX, spawnRangeCZ);
        float spawnCPosY = 2;

        Vector3 randomPos = new Vector3(spawnCPosX, spawnCPosY, spawnCPosZ);

        return randomPos;
    }
}

