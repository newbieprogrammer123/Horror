using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    [SerializeField] private Slider energySlider;

    private Light spotLight;

    private float maxEnergy = 15;
    private float currentEnergy;

    private bool isEnable;

    private int damageLight = 3;

    private void Start()
    {
        spotLight = GetComponentInChildren<Light>();

        ChangeStateLight(false);

        currentEnergy = maxEnergy;

        ChangeSlider();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeStateLight(!isEnable);
        }

        if (isEnable)
        {
            currentEnergy -= Time.deltaTime;
            ChangeSlider();

            if (currentEnergy <= 0)
            {
                ChangeStateLight(false);
            }
        }
    }

    private void ChangeStateLight(bool value)
    {
        GetComponent<BoxCollider>().enabled = value;
        isEnable = value;
        spotLight.gameObject.SetActive(value);
    }

    private void ChangeSlider()
    {
        energySlider.maxValue = maxEnergy;
        energySlider.value = currentEnergy;
    }

    public void AddEnergy(float value)
    {
        currentEnergy += value;

        if(currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }

        ChangeSlider();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().GetDamage(damageLight);
        }
    }
}
