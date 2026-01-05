using System;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float LaunchForce = 10f;
    public float UpwardSpeed = 8f;
    private Transform launchPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        launchPoint = transform;
        LaunchFood();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LaunchFood()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Use transform.right for 2D "forward" direction, and Vector2.up for upward
            Vector2 force = (Vector2)launchPoint.right * LaunchForce + Vector2.up * UpwardSpeed;

            Debug.Log(force);

            // Apply the force instantly
            rb.AddForce(force, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogError("No Rigidbody2D attached to this object!");
        }
    }
}
