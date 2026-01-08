using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class testTimerScript : MonoBehaviour
{

    public Slider timerSlider;

    public float sliderTime = 10f;

    public bool stopTimer = false;
    void Start()
    {
        timerSlider.maxValue = sliderTime;
        timerSlider.value = sliderTime;
        StartTimer();
    }

    public void StartTimer() 
    {
        StartCoroutine(StartTheTimeTicker());
    }

    IEnumerator StartTheTimeTicker()
    {
        while (stopTimer == false)
        {
            sliderTime -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (sliderTime <= 0f)
            {
                stopTimer = true;
            }

            if (stopTimer == false)
            {
                timerSlider.value = sliderTime;
            }
        }
        
    }

    public void StopTimer()
    {
        stopTimer = true;
    }   

}