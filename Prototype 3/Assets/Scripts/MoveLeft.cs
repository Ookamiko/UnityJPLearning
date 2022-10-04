using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20.0f;
    public float leftBoundary;

    private PlayerController playerController;
    private InterfaceScript interfaceScript;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        interfaceScript = GameObject.Find("Interface").GetComponent<InterfaceScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null && !playerController.IsGameOver && playerController.IsGameStart)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime * (playerController.IsRunning ? 1.5f : 1));
        }

        if (gameObject.tag.Equals("Obstacle") && transform.position.x < leftBoundary)
        {
            interfaceScript.IncreaseScore(playerController.IsRunning ? 2 : 1);
            Destroy(gameObject);
        }
    }
}
