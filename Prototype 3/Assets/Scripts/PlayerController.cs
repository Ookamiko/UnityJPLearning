using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private bool isOnGround = true;
    private bool isGameOver = false;

    public float jumpAmplifier = 10.0f;
    public float gravityModifier = 1.0f;

    public bool IsGameOver { get { return isGameOver; } }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpAmplifier, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isOnGround = true;
        } else if (collision.gameObject.tag.Equals("Obstacle"))
        {
            Debug.Log("Game Over !");
            isGameOver = true;
        }
    }
}
