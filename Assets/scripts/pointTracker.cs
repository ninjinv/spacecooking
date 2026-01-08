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
    public Text XPText;

    [Header("Score")]
    public int playerScore = 0;
    public Text ScoreText;

    [Header("Health")]
    public int Health = 20;
    public Text HealthText;

    [Header("Wave Timer")]
    public int WaveTime = 60;
    public Text WaveTimerText;
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
        updatePoints(0);
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
        // XP
        playerXP += points;
        XPText.text = "XP: " + playerXP.ToString();

        // Score
        playerScore += points;
        ScoreText.text = "Score: " + playerScore;

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
            WaveTimerText.text = WaveTime.ToString();
            yield return new WaitForSeconds(1);
            if (WaveTime <= 0)
            {
                levelUpPanelUI.SetActive(true);
                FoodLauncherScript.FoodLauncherActive = false;
                PanRef.gameObject.SetActive(false);
                TimerBool = false;
            }
            WaveTime--;
        }
    }
}
