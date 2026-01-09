using System.Collections;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private Rigidbody2D rb;

    private AudioSource audioSource; 
    public AudioClip PlateSlideIn;
    public AudioClip PlateSlideOut;

    public pointTracker pointTracker;

    public int perfectCookedPoints = 100;
    public int overCookedPoints = 25;

    private bool PlateActive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food") && PlateActive == true)
        {
            other.transform.parent = gameObject.transform;
            other.GetComponent<Rigidbody2D>().simulated = false;
            other.transform.localPosition = new Vector3(0, 0, 0);
            other.transform.localScale = new Vector3(0.3f, 0.3f, 1f);
            Food FoodScript = other.GetComponent<Food>();
            FoodScript.OnPlate = true;

            if(FoodScript.howCookedAmI == Food.cookedStates.underCooked)
            {
                // Debug.Log("Undercooked!");
                pointTracker.updatePoints(-50);
            }
            else if (FoodScript.howCookedAmI == Food.cookedStates.perfectCooked)
            {
                // Debug.Log("PERFECT!");
                pointTracker.updatePoints(perfectCookedPoints);
            }
            if (FoodScript.howCookedAmI == Food.cookedStates.overCooked)
            {
                // Debug.Log("Overcooked!");
                pointTracker.updatePoints(overCookedPoints);
            }
            if (FoodScript.howCookedAmI == Food.cookedStates.burnt)
            {
                // Debug.Log("BURNT!");
                pointTracker.updatePoints(-50);
            }

            StartCoroutine(PlateCountdown());
        }
    }

    IEnumerator PlateCountdown()
    {
        PlateActive = false;
        yield return new WaitForSeconds(0.7f);
        Vector2 start = rb.position;
        Vector2 target = start + Vector2.right * 2f;
        float speed = 3f;

        if (PlateSlideOut != null && audioSource != null) {
            audioSource.PlayOneShot(PlateSlideOut);
        }
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

        if (PlateSlideIn != null && audioSource != null) {
            audioSource.PlayOneShot(PlateSlideIn);
        }
        while (Vector2.Distance(rb.position, start) > 0.01f)
        {
            rb.MovePosition(Vector2.MoveTowards(
                rb.position,
                start,
                speed * Time.fixedDeltaTime
            ));

            yield return new WaitForFixedUpdate();
        }
        PlateActive = true;
    }
}
