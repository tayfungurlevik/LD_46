using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingBox : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var baby = collision.collider.GetComponent<Baby>();
        if (baby!=null)
        {
            baby.Die();
        }
    }
}
