using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    [Header("Health Values")]
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxHunger;
    [SerializeField]
    private float maxThirst;
    [SerializeField]
    private float maxSickness;
    [Header("Decreasing Rates")]
    [SerializeField]
    private float hungerRate;
    [SerializeField]
    private float thirstRate;
    [SerializeField]
    private float sicknessRate;

    

    private float health;
    private float hunger;
    private float thirst;
    private float sickness;
    private AudioSource audioSource;

    public static event Action<float> OnHealthChanged = delegate { };
    public static event Action<float> OnHungerChanged = delegate { };
    public static event Action<float> OnThirstChanged = delegate { };
    public static event Action<float> OnSicknessChanged = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        health = maxHealth;
        sickness = maxSickness;
        hunger = maxHunger;
        thirst = maxThirst;
        StartCoroutine(DecreaseHunger());
        StartCoroutine(DecreaseThirst());
        StartCoroutine(DecreaseSickness());
    }

    private IEnumerator DecreaseThirst()
    {
        while (thirst > 0)
        {
            thirst--;
            if (thirst <= 0)
            {
                sicknessRate /= 2;
            }
            OnThirstChanged?.Invoke(thirst / maxThirst);
            UpdateHealth();
            yield return new WaitForSeconds(thirstRate);
        }
        
    }

    private IEnumerator DecreaseSickness()
    {
        while (sickness > 0)
        {
            sickness--;
            OnSicknessChanged?.Invoke(sickness / maxSickness);
            UpdateHealth();
            yield return new WaitForSeconds(sicknessRate);
        }
    }

    private IEnumerator DecreaseHunger()
    {
        while (hunger>0)
        {
            hunger--;
            if (hunger <= 0)
            {
                sicknessRate /= 3;
            }
            OnHungerChanged?.Invoke(hunger / maxHunger);
            UpdateHealth();
            yield return new WaitForSeconds(hungerRate);
        }
        
    }

   
    internal void IncreaseHunger(float value)
    {
        hunger += value;
        if (hunger > maxHunger)
        {
            hunger = maxHunger;
        }
        OnHungerChanged?.Invoke(hunger / maxHunger);
    }

    internal void IncreaseThirst(float value)
    {
        thirst += value;
        if (thirst >= maxThirst)
        {
            thirst = maxThirst;
        }
        OnThirstChanged?.Invoke(thirst / maxThirst);
    }

    internal void IncreaseSickness(float value)
    {
        sickness += value;
        if (sickness >= maxSickness)
        {
            sickness = maxSickness;
        }
        OnSicknessChanged?.Invoke(sickness / maxSickness);
    }
    private void UpdateHealth()
    {
        health=(hunger + thirst + sickness) / 3;
        
        
        OnHealthChanged?.Invoke(health / maxHealth);
        if (health<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        audioSource.Play();
        Destroy(gameObject,1);
    }
}
