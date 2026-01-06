using UnityEngine;

public class Gravity : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            //testing how messing with time and gravity feels like in-game
            //Time.timeScale = 0.5f;
            Debug.Log("Gravity Scale set to 0");
            Physics2D.gravity = new Vector2(0, 0);
        }
    }
}
