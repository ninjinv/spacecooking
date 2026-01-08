using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

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


    private int LevelCount = 1;
    public GameObject LevelUpTitle;

    [Header("UI")]
    public GameObject YouLoseUI;
    public GameObject levelUpPanelUI;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // public int nextLevelUp = 500;

    void Start()
    {
        StartCoroutine(TimerCountdown());
        FoodLauncherScript = FoodLauncherRef.AddComponent<FoodLauncher>();
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
            // FoodLauncherRef.SetActive(false);
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
    }

    public void NextLevel()
    {
        WaveTime = 60;
        levelUpPanelUI.SetActive(false);
        // FoodLauncherRef.SetActive(true);
        FoodLauncherScript.StartCountdown();
        PanRef.gameObject.SetActive(true);
        TimerBool = true;
        StartCoroutine(TimerCountdown());
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
                // FoodLauncherRef.SetActive(false);
                FoodLauncherScript.FoodLauncherActive = false;
                PanRef.gameObject.SetActive(false);
                TimerBool = false;

                // Change Level up panal title
                LevelCount++;
                TextMeshProUGUI levelUpText = LevelUpTitle.GetComponentInChildren<TextMeshProUGUI>();
                levelUpText.text = "WAVE " + LevelCount.ToString();
            }
            WaveTime--;
        }
    }
}
