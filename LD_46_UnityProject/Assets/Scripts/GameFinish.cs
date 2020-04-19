using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    public static event Action OnGameFinishLinePassed = delegate { };
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player!=null)
        {
            OnGameFinishLinePassed?.Invoke();
        }
    }
}
