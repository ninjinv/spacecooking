using System.Collections.Generic;
using UnityEngine;

public class FoodLauncher : MonoBehaviour
{
    public List<GameObject> projectilePrefabList;
    private BoxCollider2D boxCollider;

    public 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
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
        float AreaHight = boxCollider.size.y;

        float SpawnAreaX = Random.Range(-AreaWidth/2, AreaWidth/2);
        float SpawnAreaY = Random.Range(-AreaHight/2, AreaHight/2);

        Vector2 spawnPosition = (Vector2)transform.position + new Vector2(SpawnAreaX, SpawnAreaY);

        int PrefabListIndex = Random.Range(0, projectilePrefabList.Count);
        GameObject projectilePrefab = projectilePrefabList[PrefabListIndex];

        Instantiate(projectilePrefab, spawnPosition, transform.rotation);

        Debug.Log($"Spawned projectile at {spawnPosition}");
    }
}
