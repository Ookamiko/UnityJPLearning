using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20.0f;
    public float leftBoundary;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null && !playerController.IsGameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (gameObject.tag.Equals("Obstacle") && transform.position.x < leftBoundary)
        {
            Destroy(gameObject);
        }
    }
}
