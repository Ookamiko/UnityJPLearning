using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float topBoundary = 10.0f;
    public float bottomBoundary = 10.0f;
    public float leftBoundary = 10.0f;
    public float rightBoundary = 10.0f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 translation = (Vector3.right * horizontalInput + Vector3.forward * verticalInput) * speed * Time.deltaTime;
        transform.Translate(translation);

        if (transform.position.x < leftBoundary)
        {
            transform.position = new Vector3(leftBoundary, transform.position.y, transform.position.z);
        } else if (transform.position.x > rightBoundary)
        {
            transform.position = new Vector3(rightBoundary, transform.position.y, transform.position.z);
        }

        if (transform.position.z < bottomBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomBoundary);
        } else if (transform.position.z > topBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, topBoundary);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Send projectile
            Instantiate(projectilePrefab, 
                new Vector3(transform.position.x, transform.position.y + 1, transform.position.z),
                projectilePrefab.transform.rotation);
        }
    }
}
