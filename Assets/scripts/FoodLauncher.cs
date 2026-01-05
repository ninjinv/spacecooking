using UnityEngine;

public class FoodLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // projectilePrefab = gameObject;
        GameObject newProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
