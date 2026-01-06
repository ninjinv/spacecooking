using UnityEngine;

public class Food : MonoBehaviour
{
    public float minLaunchForce = 2f;
    public float maxLaunchForce = 4f;

    public float minUpwardSpeed = 6f;
    public float maxUpwardSpeed = 8f;

    // private AudioSource audioSource; 
    // public AudioClip LaunchSoundEffect;

    public GameObject GroundFoodDetectorPrefab;
    private Transform launchPoint;

    public bool OnPlate = false;

    private bool Countdown = false;
    public float timer = 6f;
    public float CookedTime = 3f;
    public float overCookedTime = 1.5f;
    private SpriteRenderer spriteRenderer;

    public Sprite underCookedSprite;
    public Sprite perfectCookedSprite;
    public Sprite overCookedSprite;
    public Sprite burntSprite;

    public enum cookedStates
    {
        underCooked, perfectCooked, overCooked, burnt
    }

    public cookedStates howCookedAmI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // audioSource = GetComponent<AudioSource>();
        launchPoint = transform;
        LaunchFood();
    }

    // Update is called once per frame
    void Update()
    {
        //if the food is currently touching the pan and is not on a plate, aka its cooking
        if (Countdown && !OnPlate) 
        {
            //if its not burnt yet (timer less than 0)
            if (timer > 0)
            {
                //cooking the food
                timer -= Time.deltaTime;

                //the food has cooked the correct amount of time, so the food is updated to being perfectly cooked
                if (timer <= CookedTime)
                {
                    howCookedAmI = cookedStates.perfectCooked;
                }

                //the food has cooked longer than perfect, so the food is updated to being overcooked
                if (timer <= overCookedTime)
                {
                    howCookedAmI = cookedStates.overCooked;
                }
            }

            //timer has passed 0, the food is updated to being overcooked
            else
            {
                howCookedAmI = cookedStates.burnt;
            }
        }

        switch (howCookedAmI)
        {
            case cookedStates.underCooked:
                spriteRenderer.sprite = underCookedSprite;
                break;

            case cookedStates.perfectCooked:
                spriteRenderer.sprite = perfectCookedSprite;
                break;

            case cookedStates.overCooked:
                spriteRenderer.sprite = overCookedSprite;
                break;

            case cookedStates.burnt:
                spriteRenderer.sprite = burntSprite;
                break;
        }
    }

    void LaunchFood()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float LaunchForce = Random.Range(minLaunchForce, maxLaunchForce);
            float UpwardSpeed = Random.Range(minUpwardSpeed, maxUpwardSpeed);

            // Use transform.right for 2D "forward" direction, and Vector2.up for upward
            Vector2 force = (Vector2)launchPoint.right * LaunchForce + Vector2.up * UpwardSpeed;

            // if (LaunchSoundEffect != null && audioSource != null) {
            //     audioSource.PlayOneShot(LaunchSoundEffect);
            // }

            // Apply the force instantly
            rb.AddForce(force, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogError("No Rigidbody2D attached to this object!");
        }
    }

    //if the food falls outside of the game window
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("GroundFoodDetector"))
        {
            Destroy(gameObject);
        }
    }
    //if the food is touching the pan, it starts the cooking countdown
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Pan") && !Countdown)
        {
            Countdown = true;
        }
    }

    //if the food stops touching the pan, it stops the cooking countdown
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Pan") && Countdown)
        {
            Countdown = false;
            Debug.Log(timer);
        }
    }
}
