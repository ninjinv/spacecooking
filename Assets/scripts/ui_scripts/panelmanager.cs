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

    // Update is called once per frame
    void Update()
    {
        
    }
}
