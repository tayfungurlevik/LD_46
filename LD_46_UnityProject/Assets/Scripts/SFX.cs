using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    [SerializeField]private AudioClip milk,food,medicine,death;
    private AudioSource audioSource;
    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        Consumable.OnConsumableHit += Consumable_OnConsumableHit;
        Baby.OnBabyDied += Baby_OnBabyDied;
    }

    private void Baby_OnBabyDied()
    {
        audioSource.PlayOneShot(death);
    }

    private void OnDisable()
    {
        Consumable.OnConsumableHit -= Consumable_OnConsumableHit;
        Baby.OnBabyDied -= Baby_OnBabyDied;
    }
    private void Consumable_OnConsumableHit(Consumable.ConsumableType type)
    {
        switch (type)
        {
            case Consumable.ConsumableType.Food:
                audioSource.PlayOneShot(food);
                break;
            case Consumable.ConsumableType.Milk:
                audioSource.PlayOneShot(milk);
                break;
            case Consumable.ConsumableType.Medicine:
                audioSource.PlayOneShot(medicine);
                break;
            default:
                break;
        }
    }

}
