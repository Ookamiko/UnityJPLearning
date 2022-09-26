using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalsPrefabs;
    public float spawnRangeX = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            int index = Random.Range(0, animalsPrefabs.Length);
            GameObject spawn = animalsPrefabs[index];
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, 0) + transform.position;
            Quaternion spawnRot = spawn.transform.rotation * transform.rotation;

            Instantiate(spawn, spawnPos, spawnRot, transform);
        }
    }
}
