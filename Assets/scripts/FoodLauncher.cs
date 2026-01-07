using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLauncher : MonoBehaviour
{
    public List<GameObject> projectilePrefabList;
    private BoxCollider2D boxCollider;
    public GameObject pointTracker;
    public float TimeBetweenLaunch = 1.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeBetweenLaunch);
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

        // Spawn Food Projectile
        GameObject FoodProjectile = Instantiate(projectilePrefab, spawnPosition, transform.rotation);
        FoodProjectile.GetComponent<Food>().SetPointTracker(pointTracker);
    }
}
