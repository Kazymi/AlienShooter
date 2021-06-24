using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateHeal(float currentHealth)
    {
        slider.value = currentHealth;
    }
}
