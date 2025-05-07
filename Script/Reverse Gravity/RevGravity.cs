using UnityEngine;

public class RevGravity : MonoBehaviour
{
    public Rigidbody2D rb; // Reference to the Rigidbody2D on the parent GameObject
    public GameObject childObject; // Reference to the child GameObject with the tag
    public float gravityScale = 1f; // Normal gravity scale
    public float reverseGravityScale = -1f; // Reverse gravity scale

    private bool isGravityReversed = false; // Gravity state
    private float lastTapTime = 0f; // Time of the last tap
    private float doubleTapThreshold = 0.3f; // Maximum time interval between taps for a double-tap

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        if (childObject == null)
        {
            Debug.LogError("Child GameObject is not assigned in the inspector!");
        }

        // Ensure Rigidbody2D exists
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is not assigned or missing on the parent GameObject.");
        }
    }

    void Update()
    {
        if (childObject != null)
        {
            // Check the tag of the child GameObject
            if (childObject.CompareTag("Rectangle"))
            {
                HandleDoubleTap();
            }
        }
        else
        {
            Debug.LogError("Child GameObject is missing or not assigned!");
        }
    }

    private void HandleDoubleTap()
    {
        // Check for touch inputs
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Detect touch phase
            if (touch.phase == TouchPhase.Ended)
            {
                float currentTime = Time.time;

                // Check if the time between taps is within the double-tap threshold
                if (currentTime - lastTapTime < doubleTapThreshold)
                {
                    ToggleGravity();
                }

                lastTapTime = currentTime;
            }
        }
    }

    private void ToggleGravity()
    {
        isGravityReversed = !isGravityReversed;

        if (rb != null)
        {
            rb.gravityScale = isGravityReversed ? reverseGravityScale : gravityScale;
        }

        Debug.Log("Gravity Reversed: " + isGravityReversed);
    }
}
