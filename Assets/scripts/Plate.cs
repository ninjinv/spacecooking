using System.Collections;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            StartCoroutine(PlateCountdown());

        }
    }

    IEnumerator PlateCountdown()
    {
        yield return new WaitForSeconds(3f);
        // transform.position = Vector2.MoveTowards(transform.position, transform.position, step);
        Debug.Log("Move Plate");
        rb.linearVelocity = new Vector2(5, rb.linearVelocity.y);
        Debug.Log("Plate Moved");
    }
}
