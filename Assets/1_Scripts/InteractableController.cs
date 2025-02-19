using UnityEngine;

public class InteractableController : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    [SerializeField] private LightController lightCon;
    [SerializeField] private GunController gun;

    private GameObject battery;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Battery")
        {
            hand.SetActive(true);
            battery = other.gameObject;
        }
        else if (other.gameObject.tag == "Safe")
        {
            other.GetComponent<Safe>().Interacte();
        }
        else if(other.gameObject.tag == "Patronage")
        {
            gun.AddBullets(20);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Battery")
        {
            hand.SetActive(false);
            battery = null;
        }
        else if (other.gameObject.tag == "Safe")
        {
            other.GetComponent<Safe>().CancelInteracte();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (battery)
            {
                lightCon.AddEnergy(5);

                Destroy(battery);

                hand.SetActive(false);
            }
        }
    }
}
