using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] vehiclePrefabs;
    private float spawnRangeX = 8;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    private PlayerController playerControllerScript;
    private bool shouldStopSpawning = false; // Renamed variable

    void Start()
    {
        InvokeRepeating("SpawnRandomVehicle", startDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        // Update logic can be here if needed
    }

    void SpawnRandomVehicle()
    {
        if (!playerControllerScript.gameOver && !shouldStopSpawning)
        {
            int vehicleIndex = Random.Range(0, vehiclePrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeX);

            Instantiate(vehiclePrefabs[vehicleIndex], spawnPos, vehiclePrefabs[vehicleIndex].transform.rotation);
        }
    }

    public void StopSpawning() // Corrected method name
    {
        shouldStopSpawning = true;
        CancelInvoke("SpawnRandomVehicle");
    }
}
