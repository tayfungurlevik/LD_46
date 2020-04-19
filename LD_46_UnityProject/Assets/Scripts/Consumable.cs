using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public enum ConsumableType { Food,Milk,Medicine}
    [SerializeField]
    private ConsumableType type;
    [SerializeField]
    private float value;
    public static event Action<ConsumableType> OnConsumableHit = delegate { };

    
    private void OnTriggerEnter(Collider other)
    {
        var baby = other.GetComponent<Baby>();
        if (baby != null)
        {
            //audioSource.PlayOneShot(sound);
            OnConsumableHit?.Invoke(type);
            switch (type)
            {
                case ConsumableType.Food:
                    baby.IncreaseHunger(value);
                    break;
                case ConsumableType.Milk:
                    baby.IncreaseThirst(value);
                    break;
                case ConsumableType.Medicine:
                    baby.IncreaseSickness(value);
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
    
}
