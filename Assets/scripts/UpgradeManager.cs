using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
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
    }
}
