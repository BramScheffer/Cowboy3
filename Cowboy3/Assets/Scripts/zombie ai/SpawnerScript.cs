using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float spawnRadiusX;
    public float spawnRadiusY;
    public int zombieCount;
    public int maxZombieCount;
    // Start is called before the first frame update
    void Start()
    {
        zombieCount = maxZombieCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieCount < maxZombieCount)
        {
            Instantiate(zombiePrefab);
            Debug.Log("Spawn een nieuwe zombie");
        }
    }
}
