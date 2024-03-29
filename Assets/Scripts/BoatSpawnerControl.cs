using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoatSpawnerControl : MonoBehaviour
{
   
    int randomSpawnPoint, randomBoat;
    Vector2 spawnPosition;
    public GameObject[] boats;
    public GameObject civilianBoat;
    float nextCivilianBoat;
    public float civilianBoatSpawnWait = 5f; // timer to spawn civilian boat per seconds

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector2(-12f, 0.25f);
        nextCivilianBoat = Time.time;
        

        InvokeRepeating("SpawnBoat", 0f, 2f);
    }

    void SpawnBoat()
    {
        if (!HitsCounterControl.gameOver)
        {
            randomSpawnPoint = Random.Range(0, 7);
            randomBoat = Random.Range(0, boats.Length);


            switch (randomSpawnPoint)
            {
                case 0:
                    spawnPosition = new Vector2(-12f, 0.25f);
                    
                    break;
                case 1:
                    spawnPosition = new Vector2(12f, 0.25f);
                    
                    break;
                case 2:
                    spawnPosition = new Vector2(-12f, -0.5f);
                    
                    break;
                case 3:
                    spawnPosition = new Vector2(12f, -0.5f);
                    
                    break;
                case 4:
                    spawnPosition = new Vector2(-12f, -1.25f);
                    
                    break;
                case 5:
                    spawnPosition = new Vector2(12f, -1.25f);
                    
                    break;
                case 6:
                    spawnPosition = new Vector2(-12f, -2f);
                    
                    break;
                case 7:
                    spawnPosition = new Vector2(12f, -2f);
                    
                    break;
            }
            Instantiate(boats[randomBoat], spawnPosition, quaternion.identity);
             

            

            

        }
    }
    private void Update()
    {
        if (!HitsCounterControl.gameOver)
        {
            // Check if it's time to spawn civilian boat
            if (Time.time >= nextCivilianBoat)
            {
                // Instantiate civilian boat
                Instantiate(civilianBoat, spawnPosition, Quaternion.identity);

                nextCivilianBoat = Time.time + civilianBoatSpawnWait;
            }
        }
    }

}
