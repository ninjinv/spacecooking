using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject pointTrackerRef;
    public GameObject panWholeRef;
    // Reference to objects(upgrades) and if they're unlocked
    public GameObject panLeftRef;
    public bool panLeftFlipUnlocked;

    public GameObject panRightRef;
    public bool panRightFlipUnlocked;

    public GameObject bottomHoverRef;
    public bool bottomHoverUnlocked;

    private pointTracker PointTracker;
    public float cookingTime = 6f;

    // plate
    // public Plate plate;
    public List<Plate> plates;


    void Start()
    {
        PointTracker = pointTrackerRef.GetComponent<pointTracker>();
    }

    // Upgrade functions
    void FlipPanLeft()
    {
        Quaternion startRotation = Quaternion.Euler(0, 0, 50);
        Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
        float timeCount = .1f;
        float speed = 90f;
        IEnumerator Countdown()
        {
            panLeftRef.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, timeCount * speed);
            yield return new WaitForSeconds(.1f);
            panLeftRef.transform.rotation = Quaternion.Lerp(targetRotation, startRotation, timeCount * speed);
        }
        StartCoroutine(Countdown());
        //Debug.Log("cd");
    }

    void FlipPanRight()
    {
        Quaternion startRotation = Quaternion.Euler(0, 180, 50);
        Quaternion targetRotation = Quaternion.Euler(0, 180, 0);
        float timeCount = .1f;
        float speed = 90f;
        IEnumerator Countdown()
        {
            panRightRef.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, timeCount * speed);
            yield return new WaitForSeconds(.1f);
            panRightRef.transform.rotation = Quaternion.Lerp(targetRotation, startRotation, timeCount * speed);
        }
        StartCoroutine(Countdown());
        //Debug.Log("cd");
    }

    public void GainHealth(int price)
    {
        Debug.Log(PointTracker.playerXP + "   " + price);
        if (PointTracker.playerXP >= price) {
            PointTracker.playerXP -= price;
            pointTrackerRef.gameObject.GetComponent<pointTracker>().Health += 5;
        }
    }

    public void GainScore(int amount)
    {
        pointTrackerRef.gameObject.GetComponent<pointTracker>().playerScore += amount;
    }

    public void DishXPIncrease(int price)
    {
        Debug.Log(PointTracker.playerXP + "   " + price);
        if (PointTracker.playerXP >= price) {
            PointTracker.playerXP -= price;
            foreach (Plate plate in plates)
            {
                plate.perfectCookedPoints += 50;
                plate.overCookedPoints += 25;
            }
        }
    }

    void RefreshUpgrades()
    {

    }

    void AddPlate()
    {

    }

    void TrashCan()
    {

    }

    // void IncreasePanSize(float amount, int price)
    // {
    //     panWholeRef.transform.localScale += new Vector3(amount, amount, amount);
    // }
    public void IncreaseCookingSpeed(int price)
    {
        Debug.Log(PointTracker.playerXP + "   " + price);
        if (PointTracker.playerXP >= price) {
            PointTracker.playerXP -= price;
            cookingTime = 5f;
        }
    }

    public void IncreasePanSize(int price)
    {
        Debug.Log(PointTracker.playerXP + "   " + price);
        if (PointTracker.playerXP >= price) {
            PointTracker.playerXP -= price;
            panWholeRef.transform.localScale += new Vector3(0.1f, 0.2f, 1);
        }
    }

    public void DecreaseWaveTime(int price)
    {
        Debug.Log(PointTracker.playerXP + "   " + price);
        if (PointTracker.playerXP >= price) {
            PointTracker.playerXP -= price;
            PointTracker.defaultWaveTime -= 5;
        }
    }

    void Bib()
    {

    }

    void Bob()
    {

    }

    void IncreaseFoodOvercookedTimer()
    {

    }

    void Snalien()
    {

    }

    void BottomHover()
    {
        bottomHoverRef.SetActive(true);
    }

    // Check for upgrade inputs & their conditions 
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && panLeftFlipUnlocked)
        {
            FlipPanLeft();
        }

        if (Input.GetMouseButtonDown(1) && panRightFlipUnlocked)
        {
            FlipPanRight();
        }

        if (bottomHoverUnlocked)
        {
            BottomHover();
        }

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     GainHealth(5);
        //     GainScore(1000);
        //     IncreasePanSize(500);
        // }
    }
}