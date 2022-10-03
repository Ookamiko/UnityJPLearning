using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float startDelay = 2.0f;
    public float repeatTime = 3.0f;

    private PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnObstacle", startDelay);

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle()
    {
        if (playerController != null && !playerController.IsGameOver)
        {
            int index = Random.Range(0, obstaclePrefabs.Length);
            Vector3 position = transform.position + obstaclePrefabs[index].transform.position;
            Instantiate(obstaclePrefabs[index], position, transform.rotation, transform);

            Invoke("SpawnObstacle", repeatTime);
        }
    }
}
