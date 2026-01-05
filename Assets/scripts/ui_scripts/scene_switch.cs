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
        SceneManager.LoadScene("mainmenu");
    }

    public void Settings()
    {
        SceneManager.LoadScene("settings");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game"); // Works only in build
    }
}
