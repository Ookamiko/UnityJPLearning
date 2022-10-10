using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;

    private bool hasPowerUp = false;
    private bool hasPushPower = false;
    private bool canLaunchMissile = false;

    public float moveSpeed = 5.0f;

    public float powerupStrength = 25.0f;
    public float powerupTime = 7.0f;

    public GameObject missilePrefabs;
    public int missileLaunchNbr = 3;
    public float launchMissileDelay = 1.0f;
    public int maxEnemiesLocked = 3;

    private GameObject powerupIndicator;
    private Vector3 powerupIndicStartPos;
    private GameObject pushPowerupIndic;
    private GameObject missilePowerupIndic;
    private GameObject groundPowerupIndic;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

        powerupIndicator = transform.GetChild(0).gameObject;
        pushPowerupIndic = powerupIndicator.transform.GetChild(0).gameObject;
        missilePowerupIndic = powerupIndicator.transform.GetChild(1).gameObject;
        groundPowerupIndic = powerupIndicator.transform.GetChild(2).gameObject;
        powerupIndicStartPos = powerupIndicator.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * moveSpeed * verticalInput);

        powerupIndicator.transform.rotation = Quaternion.identity;
        powerupIndicator.transform.position = transform.position + powerupIndicStartPos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canLaunchMissile)
            {
                StartCoroutine(LaunchMissileRoutine());
                missilePowerupIndic.SetActive(false);
                hasPowerUp = false;
                canLaunchMissile = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power up") && !hasPowerUp)
        {
            Destroy(other.gameObject);
            hasPowerUp = true;

            if(other.gameObject.name.Contains("push"))
            {
                pushPowerupIndic.SetActive(true);
                hasPushPower = true;
                StartCoroutine(PowerupPushCountdownRoutine());
            } else if (other.gameObject.name.Contains("missile"))
            {
                canLaunchMissile = true;
                missilePowerupIndic.SetActive(true);
            }

        }
    }

    private IEnumerator LaunchMissileRoutine()
    {
        List<GameObject> enemiesLocked = new List<GameObject>();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");


        for (int i = 0; i < Mathf.Min(enemies.Length, maxEnemiesLocked); i++)
        {
            enemiesLocked.Add(enemies[i]);
        }

        for(int i = 0; i < missileLaunchNbr; i++)
        {
            foreach (GameObject current in enemiesLocked)
            {
                if (current != null)
                {
                    MissileScript tmp = Instantiate(missilePrefabs).GetComponent<MissileScript>();
                    tmp.launcher = gameObject;
                    tmp.target = current;
                }
            }
            yield return new WaitForSeconds(launchMissileDelay);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPushPower)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 enemyDirection = (collision.gameObject.transform.position - transform.position).normalized;

            enemyRb.AddForce(enemyDirection * powerupStrength, ForceMode.Impulse);
        }
    }

    private IEnumerator PowerupPushCountdownRoutine()
    {
        yield return new WaitForSeconds(powerupTime);
        hasPowerUp = false;
        hasPushPower = false;
        pushPowerupIndic.SetActive(false);
        Debug.Log("Lose push powerup");
    }
}
