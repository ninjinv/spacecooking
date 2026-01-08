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


    // Upgrade functions
    void FlipPanLeft()
    {
        Quaternion startRotation = Quaternion.Euler(0, 0, 25);
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
        Quaternion startRotation = Quaternion.Euler(0, 180, 25);
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

    void GainHealth(int amount)
    {
        pointTrackerRef.gameObject.GetComponent<pointTracker>().Health += amount;
    }

    void GainScore(int amount)
    {
        pointTrackerRef.gameObject.GetComponent<pointTracker>().playerScore += amount;
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

    void IncreasePanSize(int amount)
    {
        //float size = panWholeRef.transform.localScale.y;
        //size += amount;
        panWholeRef.transform.localScale += new Vector3(3, 0, 0);
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

    }

    // Check for upgrade inputs & their conditions 
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) && panLeftFlipUnlocked))
        {
            FlipPanLeft();
        }

        if ((Input.GetMouseButtonDown(1) && panRightFlipUnlocked))
        {
            FlipPanRight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GainHealth(5);
            GainScore(1000);
            IncreasePanSize(3);
        }
    }
}
