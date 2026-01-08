using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class pointTracker : MonoBehaviour
{
    [Header("Object Ref")]
    public GameObject FoodLauncherRef;
    private FoodLauncher FoodLauncherScript;
    public GameObject PanRef;

    [Header("XP")]
    public int playerXP = 0;
    public Text ScoreText;

    [Header("Health")]
    public Text HealthText;
    public int Health = 20;

    [Header("Wave Timer")]
    public Text WaveTimerText;
    public int WaveTimer = 60;
    private bool TimerBool = true;

    [Header("UI")]
    public GameObject YouLoseUI;
    public GameObject levelUpPanelUI;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // public int nextLevelUp = 500;

    void Start()
    {
        StartCoroutine(TimerCountdown());
        FoodLauncherScript = FoodLauncherRef.GetComponent<FoodLauncher>();
    }

    // Update is called once per frame
    void Update()
    {
        // Health
        HealthText.text = "H: " + Health;
        if (Health <= 0)
        {
            YouLoseUI.SetActive(true);
            FoodLauncherScript.FoodLauncherActive = false;
            PanRef.gameObject.SetActive(false);
        }

    }

    public void updatePoints(int points)
    {
        playerXP += points;
        ScoreText.text = "XP: " + playerXP;

        // if (playerPoints >= nextLevelUp)
        // {
        //     nextLevelUp += 500;
        //     levelUp();
        // }
    }

    public void levelUp()
    {
        //here the game would pause, a UI would pop up to choose from some randomly selected power ups
        //after the player has selected their ugrade, the game resumes
        Debug.Log("You leveled up!");
    }

    IEnumerator TimerCountdown()
    {
        while (TimerBool)
        {
            // Timer between wave
            WaveTimerText.text = WaveTimer.ToString();
            yield return new WaitForSeconds(1);
            if (WaveTimer <= 0)
            {
                levelUpPanelUI.SetActive(true);
                FoodLauncherScript.FoodLauncherActive = false;
                PanRef.gameObject.SetActive(false);
                TimerBool = false;
            }
            WaveTimer--;
        }
    }
}
