using UnityEngine;
using UnityEngine.EventSystems; // Required for checking UI interactions

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    private bool grounded;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Move player
        rb.velocity = new Vector2(speed, rb.velocity.y);

        // Jump on key press or valid touch input
        if ((Input.GetKey(KeyCode.Space) || IsTouchInputDetected()) && grounded)
        {
            Jump();
        }

        // Set animator parameters
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Set jump velocity
        grounded = false;
    }

    private bool IsTouchInputDetected()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Ensure the touch is not over any UI element
            if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                return true;
            }
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
