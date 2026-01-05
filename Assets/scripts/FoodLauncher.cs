using UnityEngine;

public class FoodLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;

    private BoxCollider2D boxCollider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        // projectilePrefab = gameObject;
        GameObject newProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnFood();
        }
    }

    void SpawnFood()
    {
        float AreaWidth = boxCollider.size.x;
        Debug.Log(AreaWidth);
        float AreaHight = boxCollider.size.y;
        Debug.Log(AreaHight);

        float SpawnAreaX = Random.Range(-AreaWidth/2, AreaWidth/2);
        Debug.Log("randomNumX: " + SpawnAreaX);
        float SpawnAreaY = Random.Range(-AreaHight/2, AreaHight/2);
        Debug.Log("randomNumY: " + SpawnAreaY);

        Vector2 spawnPosition = (Vector2)transform.position + new Vector2(SpawnAreaX, SpawnAreaY);
        Instantiate(projectilePrefab, spawnPosition, transform.rotation);

        Debug.Log($"Spawned projectile at {spawnPosition}");
    }
}
