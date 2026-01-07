using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_switch : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("placegolder*");
    }

    public void resume()
    {

    }

    public void Mainmenu()
    {
        //SceneManager.LoadScene("mainmenu");
        Debug.Log("Mainmenu scene loading is disabled for testing purposes.");
    }

    public void Settings()
    {
        // SceneManager.LoadScene("settings");
    }

    public void QuitGame()
    {
        Debug.Log("Quit game"); // Works only in build
        Application.Quit();
    }

    // Move Scene
    public void MoveScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
