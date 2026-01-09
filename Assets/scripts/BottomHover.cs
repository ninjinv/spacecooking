using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class BottomHover : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        float pingPongValue = Mathf.PingPong(Time.time * 8, 12);

        Vector3 newPosition = new Vector3(-6, -4.5f, 0) + new Vector3(pingPongValue, 0.0f, 0.0f);

        transform.position = newPosition;
    }
}
