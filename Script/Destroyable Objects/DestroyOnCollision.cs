using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentCollisionHandler : MonoBehaviour
{
    public LayerMask blockLayer; // Layer mask for "block" objects
    private Animator anim;       // Animator component on the parent GameObject
    private UImanager uIManager; // Reference to the UI Manager
    public GameObject childObject; // Reference to the child GameObject

    private void Start()
    {
        // Get the Animator component on the parent GameObject
        anim = GetComponent<Animator>();
        uIManager = FindObjectOfType<UImanager>();

        // Validate that the child GameObject is assigned
        if (childObject == null)
        {
            Debug.LogError("Child GameObject is not assigned in the inspector!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is in the blockLayer
        if (((1 << collision.gameObject.layer) & blockLayer) != 0)
        {
            // Ensure childObject is assigned and valid
            if (childObject != null)
            {
                string childTag = childObject.tag;

                if (childTag == "Cube")
                {
                    // Destroy the block object
                    Destroy(collision.gameObject);
                }
                else if (childTag == "Rectangle" || childTag == "Player")
                {
                    // Trigger the die animation on the parent GameObject
                    if (anim != null)
                    {
                        anim.SetTrigger("die");
                    }

                    // Disable the player's movement script
                    PlayerMovement playerMovement = GetComponent<PlayerMovement>();
                    if (playerMovement != null)
                    {
                        playerMovement.enabled = false;
                    }

                    // Trigger Game Over via UI Manager
                    if (uIManager != null)
                    {
                        uIManager.GameOver();
                    }
                }
            }
            else
            {
                Debug.LogError("Child GameObject is missing or not assigned!");
            }
        }
    }
}
