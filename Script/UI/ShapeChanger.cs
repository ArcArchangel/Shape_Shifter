using UnityEngine;

public class ShapeChanger : MonoBehaviour
{
    public Sprite cubeSprite;   // Sprite for the Cube
    public Sprite sphereSprite; // Sprite for the Sphere
    public Sprite plateSprite;  // Sprite for the Plate

    public GameObject player;   // Reference to the "Player" child GameObject
    public GameObject parentObject; // Reference to the parent GameObject with the Animator

    private Animator parentAnimator; // Animator reference
    private string currentTag = "Cube"; // Start with "Cube"

    void Start()
    {
        // Validate the player reference
        if (player == null)
        {
            Debug.LogError("Player GameObject is not assigned in the inspector!");
        }

        // Validate and get the Animator from the parent GameObject
        if (parentObject != null)
        {
            parentAnimator = parentObject.GetComponent<Animator>();

            if (parentAnimator == null)
            {
                Debug.LogError("No Animator found on the parent GameObject!");
            }
        }
        else
        {
            Debug.LogError("Parent GameObject is not assigned in the inspector!");
        }
    }

    public void OnButtonClick()
    {
        if (player != null && parentAnimator != null)
        {
            // Change the tag and sprite based on the current tag
            SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                if (currentTag == "Cube")
                {
                    player.tag = "Player";
                    spriteRenderer.sprite = sphereSprite;
                    ReplaceCollider<CircleCollider2D>();
                    currentTag = "Player";

                    // Trigger the sphere animation
                    parentAnimator.SetTrigger("sphere");
                }
                else if (currentTag == "Player")
                {
                    player.tag = "Rectangle";
                    spriteRenderer.sprite = plateSprite;
                    ReplaceCollider<BoxCollider2D>(new Vector2(1f, 0.3f)); // Custom size for rectangle
                    currentTag = "Rectangle";

                    // Trigger the rectangle animation
                    parentAnimator.SetTrigger("plate");
                }
                else if (currentTag == "Rectangle")
                {
                    player.tag = "Cube";
                    spriteRenderer.sprite = cubeSprite;
                    ReplaceCollider<BoxCollider2D>(); // Default size for cube
                    currentTag = "Cube";

                    // Trigger the cube animation
                    parentAnimator.SetTrigger("cube");
                }
            }
            else
            {
                Debug.LogError("The 'Player' GameObject does not have a SpriteRenderer component!");
            }
        }
    }

    private void ReplaceCollider<T>(Vector2? size = null) where T : Collider2D
    {
        // Remove any existing collider
        Collider2D existingCollider = player.GetComponent<Collider2D>();
        if (existingCollider != null)
        {
            Destroy(existingCollider);
        }

        // Add the new collider
        T newCollider = player.AddComponent<T>();

        // If a BoxCollider2D is added and a custom size is provided, update its size
        if (newCollider is BoxCollider2D boxCollider && size.HasValue)
        {
            boxCollider.size = size.Value;
        }
    }
}
