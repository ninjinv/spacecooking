using System.Runtime.CompilerServices;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public int currentDimension = 1;
    public float dimensionCountdown;
    void Start()
    {
        dimensionCountdown = Random.Range(10, 31);
        // Debug.Log(dimensionCountdown);
    }

    void Update()
    {
        if (Time.timeScale != 0f)
        {
            dimensionCountdown -= Time.unscaledDeltaTime;
        }

        if (dimensionCountdown <= 0)
        {
            selectNewDimension();
            dimensionCountdown = Random.Range(10, 31);
            // Debug.Log("new timer:" + dimensionCountdown);
        }
    }

    public void selectNewDimension()
    {
        int newDimension = Random.Range(1, 5);

        if (newDimension == currentDimension)
        {
            selectNewDimension();
        }

        else if (newDimension != currentDimension)
        {
            currentDimension = newDimension;
            gravityChange(currentDimension);
        }
    }

    public void gravityChange(int dimension)
    {
        if (dimension == 1)
        {
            //dimension 1 = earth, timescale and gravity behaves like normal
            // Debug.Log("EARTH");
            Physics2D.gravity = new Vector2(0, -9.81f);
            Time.timeScale = 1f;

        }

        else if (dimension == 2)
        {
            //dimension 2 = moon, timescale is reduced and gravity is reduced
            // Debug.Log("MOON");
            Physics2D.gravity = new Vector2(0, -5f);
            Time.timeScale = 0.5f;
        }

        else if (dimension == 3)
        {
            //dimension 3 = upside down where everything slowly floats uwards
            // Debug.Log("UPSIDE DOWN");
            Physics2D.gravity = new Vector2(0, 2f);
            Time.timeScale = 1f;
        }

        else if (dimension == 4)
        {
            //dimension 4 = right-topia, where gravity is going right
            // Debug.Log("RIGHT-TOPIA");
            Physics2D.gravity = new Vector2(5f, 0f);
            Time.timeScale = 0.75f;
        }

        else
        {
            Debug.Log("unknown dimension?");
        }
    }
}
