using System.Collections.Generic;
using UnityEngine;


public class Food : MonoBehaviour
{
    public float minLaunchForce = 2f;
    public float maxLaunchForce = 4f;

    public float minUpwardSpeed = 6f;
    public float maxUpwardSpeed = 8f;

    public GameObject GroundFoodDetectorPrefab;
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
            float LaunchForce = Random.Range(minLaunchForce, maxLaunchForce);
            float UpwardSpeed = Random.Range(minUpwardSpeed, maxUpwardSpeed);

            // Use transform.right for 2D "forward" direction, and Vector2.up for upward
            Vector2 force = (Vector2)launchPoint.right * LaunchForce + Vector2.up * UpwardSpeed;

            // Apply the force instantly
            rb.AddForce(force, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogError("No Rigidbody2D attached to this object!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("GroundFoodDetector"))
        {
            Destroy(gameObject);
        }
    }
}
