using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    public float topBoundary = 50.0f;
    public float bottomBoundary = -10.0f;
    public float leftBoundary = 50.0f;
    public float rightBoundary = 50.0f;

    private GameObject interfaceObject;

    // Start is called before the first frame update
    void Start()
    {
        interfaceObject = GameObject.Find("Interface");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBoundary || transform.position.z < bottomBoundary ||
            transform.position.x < leftBoundary || transform.position.x > rightBoundary)
        {
            Destroy(gameObject);

            if (gameObject.tag == "Enemy")
            {
                if (interfaceObject != null)
                {
                    interfaceObject.GetComponent<InterfaceLogic>().LoseLive();
                }
            }
        }
    }
}
