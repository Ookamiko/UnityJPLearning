using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    private GameObject interfaceObject;

    // Start is called before the first frame update
    void Start()
    {
        interfaceObject = GameObject.Find("Interface");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (other.tag == "Projectile")
        {
            Destroy(other.gameObject);

            if (interfaceObject != null)
            {
                interfaceObject.GetComponent<InterfaceLogic>().AddScore();
            }
        }
        else if (other.tag == "Player")
        {
            if (interfaceObject != null)
            {
                interfaceObject.GetComponent<InterfaceLogic>().LoseLive();
            }
        }
    }
}
