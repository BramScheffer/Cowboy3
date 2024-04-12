using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float spawnRadiusX;
    public float spawnRadiusY;
    public int maxZombieCount;
    private int currentZombieCount;

    void Start()
    {
        currentZombieCount = maxZombieCount;
        SpawnZombies(maxZombieCount);
    }

    void Update()
    {
        if (currentZombieCount < maxZombieCount)
        {
            SpawnZombies(1);
        }
    }

    void SpawnZombies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
            currentZombieCount++;
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(-spawnRadiusX, spawnRadiusX);
        float randomY = Random.Range(-spawnRadiusY, spawnRadiusY);
        Vector3 randomSpawnPosition = new Vector3(randomX, 0, randomY) + transform.position;
        return randomSpawnPosition;
    }
}

