using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalsPrefabs;
    public float spawnRangeX = 20.0f;
    public float spawnStartDelay = 2;
    public float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnimalRandom", spawnStartDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnAnimalRandom()
    {
        int index = Random.Range(0, animalsPrefabs.Length);
        GameObject spawn = animalsPrefabs[index];
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, 0) + transform.position;
        Quaternion spawnRot = spawn.transform.rotation * transform.rotation;

        Instantiate(spawn, spawnPos, spawnRot, transform);
    }
}
