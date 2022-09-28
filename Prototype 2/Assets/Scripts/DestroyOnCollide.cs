using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    public int hungerMax = 1;

    private int filledHunger = 0;

    private GameObject interfaceObject;
    public HungerBar hungerBar;

    // Start is called before the first frame update
    void Start()
    {
        interfaceObject = GameObject.Find("Interface");
        hungerMax = hungerMax > 0 ? hungerMax : 1;

        if (hungerBar != null)
        {
            hungerBar.SetMaxHunger(hungerMax);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Projectile")
        {
            Destroy(other.gameObject);

            filledHunger++;

            if (hungerBar != null)
            {
                hungerBar.SetHunger(filledHunger);
            }

            if (filledHunger == hungerMax)
            {
                Destroy(gameObject);
                if (interfaceObject != null)
                {
                    interfaceObject.GetComponent<InterfaceLogic>().AddScore();
                }
            }
        }
        else if (other.tag == "Player")
        {
            Destroy(gameObject);

            if (interfaceObject != null)
            {
                interfaceObject.GetComponent<InterfaceLogic>().LoseLive();
            }
        }
    }
}
