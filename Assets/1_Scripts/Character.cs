using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] protected Slider healthSlider;
    [SerializeField] private int maxHealth;

    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;

        UpdateUi();
    }

    public void GetDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            UpdateUi();

            if (currentHealth <= 0)
            {
                currentHealth = 0;

                Death();
            }
        }
    }

    private void UpdateUi()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    protected virtual void Death() { }
}
