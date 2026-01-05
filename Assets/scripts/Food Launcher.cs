using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float LaunchForce = 70f;
    private Transform launchPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // projectilePrefab = gameObject;
        launchPoint = transform;
        LaunchFood();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LaunchFood()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);
        // Get the Rigidbody component and add forward force
        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Apply an instant force in the forward direction of the launch point
            rb.AddForce(launchPoint.forward * LaunchForce, ForceMode.Impulse);
        }
    }


}
