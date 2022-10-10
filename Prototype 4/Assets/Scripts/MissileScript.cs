using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public GameObject target = null;
    public GameObject launcher = null;

    public float speed;
    public float missileStrength = 10.0f;

    private Rigidbody missileRb;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetDirection = (target.transform.position - launcher.transform.position).normalized;
        transform.position = launcher.transform.position + targetDirection * 2;
        missileRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 targetDirection = (target.transform.position - transform.position).normalized;

            missileRb.AddForce(targetDirection * speed);
            transform.LookAt(target.transform);
            transform.Rotate(90, 0, 0);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
        Vector3 enemyDirection = (other.gameObject.transform.position - transform.position).normalized;

        if (other.gameObject == target)
        {
            enemyRb.AddForce(enemyDirection * missileStrength, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
