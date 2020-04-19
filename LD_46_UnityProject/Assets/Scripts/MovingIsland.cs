using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingIsland : MonoBehaviour
{

    private Vector3 pointA, pointB;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float MovingDistance = 2;
    private Vector3 target;
    float totalDistance;
    private void Start()
    {
        pointA = transform.position;
        pointB = pointA+transform.forward.normalized * MovingDistance;
        target = pointB;
        transform.position = pointA;
        totalDistance = Vector3.Distance(pointA, pointB);
    }
    private void Update()
    {
        var MoveVector = target - transform.position;
        transform.position += MoveVector.normalized * speed * Time.deltaTime;
        var distance = Vector3.Distance(target, transform.position);
        if (distance<=0.1f)
        {
            transform.position = target;
            ChangeTarget(target);
        }
    }

    private void ChangeTarget(Vector3 currentTarget)
    {
        if (currentTarget==pointB)
        {
            target = pointA;
        }
        else
        {
            target = pointB;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.collider.GetComponent<PlayerController>();
        if (player!=null)
        {
            player.transform.SetParent(gameObject.transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        var player = collision.collider.GetComponent<PlayerController>();
        if (player != null)
        {
            player.transform.parent = null;
        }
    }
}
