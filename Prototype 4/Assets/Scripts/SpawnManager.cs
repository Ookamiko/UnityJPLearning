using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int waveNumber = 1;

    public GameObject[] enemies;
    public GameObject[] powerups;

    public float minSpawnRange = 5.0f;
    public float maxSpawnRange = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(waveNumber);
        SpawnPowerup(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            waveNumber++;
            SpawnEnemies(waveNumber);
            SpawnPowerup(1);
        }
    }

    private void SpawnEnemies(int enemyNbr)
    {
        for (int i = 0; i < enemyNbr; i++)
        {
            int index = Random.Range(0, enemies.Length);
            Instantiate(enemies[index], RandomSpawnPosition(), enemies[index].transform.rotation, transform);
        }
    }

    private void SpawnPowerup(int powerupNbr)
    {
        for(int i = 0; i < powerupNbr; i++)
        {
            int index = Random.Range(0, powerups.Length);
            Instantiate(powerups[index], RandomSpawnPosition(), powerups[index].transform.rotation);
        }
    }

    private Vector3 RandomSpawnPosition()
    {
        float range = Random.Range(minSpawnRange, maxSpawnRange);
        float xAxis = Random.Range(-range, range);
        float zAxis = Mathf.Sqrt(Mathf.Pow(range, 2) - Mathf.Pow(xAxis, 2)) * (Random.Range(0, 2) == 0 ? 1 : -1);

        return new Vector3(xAxis, 0, zAxis);
    }
}
