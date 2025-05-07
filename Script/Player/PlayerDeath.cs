using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    
    private Animator anim;
    private UImanager uIManager;

    private void Start()
    {
        // Get the animator component of the player
        anim = GetComponent<Animator>();
        uIManager = FindObjectOfType<UImanager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            // Handle Player Death
            if (anim != null)
            {
                anim.SetTrigger("die");
            }
            
            GetComponent<PlayerMovement>().enabled = false;

            // Load a "Game Over" scene
            uIManager.GameOver();
        }
    }
}
