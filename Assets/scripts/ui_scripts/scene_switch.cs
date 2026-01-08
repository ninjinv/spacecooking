using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_switch : MonoBehaviour
{

    public Gravity gravity;

    // public void PlayGame()
    // {
    //     SceneManager.LoadScene("placegolder*");
    // }

    public void resume(GameObject PauseCanves)
    {
        //this will return the timescale to whatever it was previously set to
        gravity.gravityChange(gravity.currentDimension);
        PauseCanves.SetActive(false);
    }

    // public void Mainmenu()
    // {
    //     //SceneManager.LoadScene("mainmenu");
    //     Debug.Log("Mainmenu scene loading is disabled for testing purposes.");
    // }

    public void Settings()
    {
        // SceneManager.LoadScene("settings");
    }

    public void QuitGame()
    {
        Debug.Log("Quit game"); // Works only in build
        Application.Quit();
    }

    public void PauseGame(GameObject PauseCanves)
    {
        Time.timeScale = 0f;
        PauseCanves.SetActive(true);
    }

    // Move Scene
    public void MoveScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
