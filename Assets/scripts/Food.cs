using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;


public class Food : MonoBehaviour
{
    public float minLaunchForce = 2f;
    public float maxLaunchForce = 4f;

    public float minUpwardSpeed = 6f;
    public float maxUpwardSpeed = 8f;

    public GameObject GroundFoodDetectorPrefab;
    private Transform launchPoint;

    public bool OnPlate = false;

    private bool Countdown = false;
    public float timer = 6f;
    public float CookedTime = 3f;
    public Color CookedColor;
    public Color BurnedColor = new Color(0f, 0f, 0f, 1f);
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        launchPoint = transform;
        LaunchFood();
    }

    // Update is called once per frame
    void Update()
    {
        if (Countdown && !OnPlate) {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                Debug.Log(timer);
                if (timer <= CookedTime)
                {
                    Debug.Log("cooked");
                    spriteRenderer.color = CookedColor;
                }
            }
            else
            {
                Debug.Log("burned");
                spriteRenderer.color = BurnedColor;
            }
        }
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("GroundFoodDetector"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pan"))
        {
            Countdown = true;
        }
    }
}
