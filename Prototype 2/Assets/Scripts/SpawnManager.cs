using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalsPrefabs;
    public float spawnRangeX = 20.0f;
    public float spawnRangeZ = 20.0f;
    public float spawnStartDelay = 2;
    public float spawnMinInterval = 0;
    public float spawnMaxInterval = 3;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnAnimalRandom", spawnStartDelay + Random.Range(spawnMinInterval, spawnMaxInterval));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnAnimalRandom()
    {
        int index = Random.Range(0, animalsPrefabs.Length);
        GameObject spawn = animalsPrefabs[index];
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ)) + transform.position;
        Quaternion spawnRot = spawn.transform.rotation * transform.rotation;

        Instantiate(spawn, spawnPos, spawnRot, transform);

        Invoke("SpawnAnimalRandom", Random.Range(spawnMinInterval, spawnMaxInterval));
    }
}
