using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    public float topBoundary = 50.0f;
    public float bottomBoundary = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBoundary)
        {
            // Food despawn
            Destroy(gameObject);
        } else if (transform.position.z < bottomBoundary)
        {
            // Animal despawn
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }
    }
}