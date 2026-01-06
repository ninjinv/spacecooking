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
            Food FoodScript = other.GetComponent<Food>();
            FoodScript.OnPlate = true;
            StartCoroutine(PlateCountdown());

        }
    }

    IEnumerator PlateCountdown()
    {
        yield return new WaitForSeconds(1f);
        Vector2 start = rb.position;
        Vector2 target = start + Vector2.right * 2f;
        float speed = 3f;

        while (Vector2.Distance(rb.position, target) > 0.01f)
        {
            rb.MovePosition(Vector2.MoveTowards(
                rb.position,
                target,
                speed * Time.fixedDeltaTime
            ));

            yield return new WaitForFixedUpdate();
        }
        Destroy(transform.GetChild(0).gameObject);
        while (Vector2.Distance(rb.position, start) > 0.01f)
        {
            rb.MovePosition(Vector2.MoveTowards(
                rb.position,
                start,
                speed * Time.fixedDeltaTime
            ));

            yield return new WaitForFixedUpdate();
        }
    }
}
