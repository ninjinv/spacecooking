using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLauncher : MonoBehaviour
{
    public List<GameObject> projectilePrefabList;
    private BoxCollider2D boxCollider;
    public GameObject pointTracker;
    public float MinTimeBetweenLaunch = 4f;
    public float MaxTimeBetweenLaunch = 8f;
    public bool FoodLauncherActive = true;

    // public float cookingTime = 6f;



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

    public void StartCountdown()
    {
        FoodLauncherActive = true;
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (FoodLauncherActive)
        {
            float TimeBetweenLaunch = Random.Range(MinTimeBetweenLaunch, MaxTimeBetweenLaunch);
            yield return new WaitForSeconds(TimeBetweenLaunch);
            SpawnFood();
        }
    }

    void SpawnFood()
    {
        Bounds bounds = boxCollider.bounds;

        float SpawnAreaX = Random.Range(bounds.min.x, bounds.max.x);
        float SpawnAreaY = Random.Range(bounds.min.y, bounds.max.y);

        Vector2 spawnPosition = new Vector2(SpawnAreaX, SpawnAreaY);

        int PrefabListIndex = Random.Range(0, projectilePrefabList.Count);
        GameObject projectilePrefab = projectilePrefabList[PrefabListIndex];

        // Spawn Food Projectile
        GameObject FoodProjectile = Instantiate(projectilePrefab, spawnPosition, transform.rotation);
        FoodProjectile.GetComponent<Food>().SetPointTracker(pointTracker);
    }
}
