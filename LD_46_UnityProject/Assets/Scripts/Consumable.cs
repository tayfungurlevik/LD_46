using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    enum ConsumableType { Food,Milk,Medicine}
    [SerializeField]
    private ConsumableType type;
    [SerializeField]
    private float value;
    [SerializeField] AudioClip sound;

    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        var baby = other.GetComponent<Baby>();
        if (baby != null)
        {
            audioSource.PlayOneShot(sound);
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
            Destroy(gameObject, 0.4f);
        }
    }
    
}
