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
    public int defaultWaveTime;
    private bool TimerBool = true;


    private int LevelCount = 1;
    public GameObject LevelUpTitle;

    [Header("UI")]
    public GameObject YouLoseUI;
    public GameObject levelUpPanelUI;

    [Header("Gravity")]
    public Gravity gravity;
    

    void Start()
    {
        defaultWaveTime = WaveTime;
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
        XPText.text = "XP: " + playerXP.ToString();
        ScoreText.text = "Score: " + playerScore.ToString();

    }

    public void updatePoints(int points)
    {
        // XP
        playerXP += points;
        XPText.text = "XP: " + playerXP.ToString();

        // Score
        playerScore += points;
        ScoreText.text = "Score: " + playerScore.ToString();
    }

    public void NextLevel()
    {
        WaveTime = defaultWaveTime;
        gravity.gravityChange(gravity.currentDimension);
        levelUpPanelUI.SetActive(false);
        FoodLauncherRef.SetActive(true);
        FoodLauncherScript.StartCountdown();
        PanRef.gameObject.SetActive(true);
        TimerBool = true;
        gravity.gravityChange(gravity.currentDimension);
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
                Time.timeScale = 0f;
                levelUpPanelUI.SetActive(true);
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
