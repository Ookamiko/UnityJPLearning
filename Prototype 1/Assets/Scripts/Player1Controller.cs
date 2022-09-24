using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float speed = 15.0f;
    public float turnSpeed = 2.0f;

    // Switch camera
    public Camera topView;
    public Camera driverView;

    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        topView.enabled = true;
        driverView.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get Player Input (Found in edit > preference > input manager)
        horizontalInput = Input.GetAxis("HorizontalP1");
        forwardInput = Input.GetAxis("VerticalP1");

        // Move forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Turn (only when moving)
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput * (forwardInput != 0 ? 1 : 0));

        // Change Camera
        if (Input.GetButtonDown("Change CameraP1"))
        {
            topView.enabled = !topView.enabled;
            driverView.enabled = !driverView.enabled;
        }
    }
}
