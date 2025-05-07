using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedModifier : MonoBehaviour
{
    public float speedMultiplier = 0.5f; // Multiplier for reduced speed
    public float slowDownDuration = 5.0f; // Duration of speed reduction
    private float originalSpeed;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        originalSpeed = playerMovement.speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            // Slow down the player
            playerMovement.speed *= speedMultiplier;
            Invoke("RestoreSpeed", slowDownDuration);
        }
    }

    void RestoreSpeed()
    {
        playerMovement.speed = originalSpeed;
    }
}
