using UnityEngine;

public class panelmanager : MonoBehaviour
{
    [Header("UI")]
    public GameObject completeUI;
    public GameObject pauseUI;
    void Start()
    {
        completeUI?.SetActive(false);
        pauseUI?.SetActive(false);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseUI?.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseUI?.SetActive(false);
    }
}
