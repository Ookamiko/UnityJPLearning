using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;

    private bool hasPowerUp = false;

    public float moveSpeed = 5.0f;
    public float powerupStrength = 25.0f;
    public float powerupTime = 7.0f;

    private GameObject powerupIndicator;
    private Vector3 powerupIndicStartPos;
    private int waitingPowerup = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

        powerupIndicator = transform.GetChild(0).gameObject;
        powerupIndicStartPos = powerupIndicator.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * moveSpeed * verticalInput);

        powerupIndicator.transform.rotation = Quaternion.identity;
        powerupIndicator.transform.position = transform.position + powerupIndicStartPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power up"))
        {
            waitingPowerup++;
            Destroy(other.gameObject);

            if (!hasPowerUp)
            {
                hasPowerUp = true;
                powerupIndicator.SetActive(true);
                StartCoroutine(PowerupCountdownRoutine());
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 enemyDirection = (collision.gameObject.transform.position - transform.position).normalized;

            enemyRb.AddForce(enemyDirection * powerupStrength, ForceMode.Impulse);
        }
    }

    private IEnumerator PowerupCountdownRoutine()
    {
        while (waitingPowerup > 0)
        {
            yield return new WaitForSeconds(powerupTime);
            waitingPowerup--;
        }
        hasPowerUp = false;
        powerupIndicator.SetActive(false);
        Debug.Log("Lose powerup");
    }
}
