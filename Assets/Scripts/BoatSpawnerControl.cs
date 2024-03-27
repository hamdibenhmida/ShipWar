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
    public  List<GameObject> boatsToSpawn = new List<GameObject>();
    public int numberOfReplicas = 10;
    public GameObject civilianBoat;
    float nextCivilianBoat;
    public float civilianBoatSpawnWait = 5f; // Interval to spawn civilian boat

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector2(-12f, 0.25f);
        nextCivilianBoat = Time.time;
        foreach (GameObject boat in boats)
        {
            for (int i = 0;i < numberOfReplicas; i++)
            {
                boatsToSpawn.Add(boat);
            }
        }
        Shuffle(boatsToSpawn);

        InvokeRepeating("SpawnBoat", 0f, 2f);
    }

    private void Shuffle(List<GameObject> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            GameObject value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    void SpawnBoat()
    {
        if (!HitsCounterControl.gameOver)
        {
            randomSpawnPoint = Random.Range(0, 7);
            randomBoat = Random.Range(0, boatsToSpawn.Count);


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
            Instantiate(boatsToSpawn[randomBoat], spawnPosition, quaternion.identity);
             

            

            

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
