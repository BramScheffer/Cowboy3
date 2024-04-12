using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float spawnRadiusX;
    public float spawnRadiusY;
    private int currentZombieCount;

    public float spawnInterval = 5f; // Interval between zombie spawns
    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval; // Set initial spawn time
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnZombie();
            nextSpawnTime = Time.time + spawnInterval; // Update next spawn time
        }
    }

    void SpawnZombie()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(-spawnRadiusX, spawnRadiusX);
        float randomY = Random.Range(-spawnRadiusY, spawnRadiusY);
        Vector3 randomSpawnPosition = new Vector3(randomX, 0, randomY) + transform.position;
        return randomSpawnPosition;
    }
}
