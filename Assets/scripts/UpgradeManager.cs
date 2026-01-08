using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject PanLeftRef;
    public bool PanLeftFlipUnlocked;

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(2f);
    }

    void FlipPanLeft()
    {
        PanLeftRef.transform.eulerAngles = new Vector3(0, 0, -25);
        StartCoroutine(Countdown());
        PanLeftRef.transform.eulerAngles = new Vector3(0, 0, 25);
    }

    // Update is called once per frame
    void Update()
    {
        if (PanLeftFlipUnlocked & Input.GetMouseButtonDown(0))
        {
            FlipPanLeft();
        }
    }
}
