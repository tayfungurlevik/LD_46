using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{
    [SerializeField]
    private Image healthImage;
    [SerializeField]
    private Image hungerImage;
    [SerializeField]
    private Image thirstImage;
    [SerializeField]
    private Image sickImage;
    private void OnEnable()
    {
        Baby.OnHungerChanged += Baby_OnHungerChanged;
        Baby.OnThirstChanged += Baby_OnThirstChanged;
        Baby.OnSicknessChanged += Baby_OnSicknessChanged;
        Baby.OnHealthChanged += Baby_OnHealthChanged;
    }

    private void Baby_OnHealthChanged(float obj)
    {
        healthImage.fillAmount = obj;
    }

    private void Baby_OnSicknessChanged(float obj)
    {
        sickImage.fillAmount = obj;
        
    }

    private void Baby_OnThirstChanged(float obj)
    {
        thirstImage.fillAmount = obj;
    }

    private void Baby_OnHungerChanged(float obj)
    {
        hungerImage.fillAmount = obj;
    }
    private void OnDisable()
    {
        Baby.OnHungerChanged -= Baby_OnHungerChanged;
        Baby.OnThirstChanged -= Baby_OnThirstChanged;
        Baby.OnSicknessChanged -= Baby_OnSicknessChanged;
        Baby.OnHealthChanged -= Baby_OnHealthChanged;
    }
}
