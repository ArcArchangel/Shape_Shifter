using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private float defaultGravityScale = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultGravityScale = rb.gravityScale; 
    }

    void Update()
    {
        if (gameObject.CompareTag("Rectangle"))
        {
            if (Input.GetKeyDown(KeyCode.Keypad8)) 
            {
                rb.gravityScale = -defaultGravityScale; // Reverse gravity
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2)) 
            {
                rb.gravityScale = defaultGravityScale; // Restore default gravity
            }
        }
    }
}
