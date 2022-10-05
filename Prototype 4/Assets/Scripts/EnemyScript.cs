using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody objectRb;
    private GameObject player;

    public float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;

        objectRb.AddForce(direction * moveSpeed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
