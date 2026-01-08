using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    // Reference to objects(upgrades) and if they're unlocked
    public GameObject PanLeftRef;
    public bool PanLeftFlipUnlocked;

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(2f);
    }

    // Upgrade functions
    void FlipPanLeft()
    {
        PanLeftRef.transform.eulerAngles = new Vector3(0, 0, -25);
        StartCoroutine(Countdown());
        PanLeftRef.transform.eulerAngles = new Vector3(0, 0, 25);
    }



    // Check for upgrade inputs & their conditions 
    void Update()
    {
        if (PanLeftFlipUnlocked & Input.GetMouseButtonDown(0))
        {
            FlipPanLeft();
        }
    }
}
