using UnityEngine;

public class Plate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            other.transform.parent = gameObject.transform;
            other.GetComponent<Rigidbody2D>().simulated = false;
            other.transform.localPosition = new Vector3(0, 0, 0);
            other.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

        }
    }
}
