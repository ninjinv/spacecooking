using UnityEngine;
using UnityEngine.UI;

public class pointTracker : MonoBehaviour
{
    public Text ScoreText;
    public Text HealthText;
    public int Health = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int playerPoints = 0;
    public int nextLevelUp = 500;

    void Start()
    {
        Debug.Log(playerPoints);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log(playerPoints);
        }
        HealthText.text = "Health: " + Health;
    }

    public void updatePoints(int points)
    {
        playerPoints = playerPoints + points;
        Debug.Log("Points: " + playerPoints);
        ScoreText.text = "Score: " + playerPoints;

        if (playerPoints >= nextLevelUp)
        {
            nextLevelUp = nextLevelUp + 500;
            levelUp();
        }
    }

    public void levelUp()
    {
        //here the game would pause, a UI would pop up to choose from some randomly selected power ups
        //after the player has selected their ugrade, the game resumes
        Debug.Log("You leveled up!");
    }
}
