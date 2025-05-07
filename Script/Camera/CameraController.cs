using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float smoothSpeed = 5f; // Smooth movement speed
    public Vector3 offset; // Offset for the camera position

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        // Calculate default offset for bottom-left corner placement
        if (cam.orthographic)
        {
            float vertExtent = cam.orthographicSize; // Vertical size of the camera
            float horizExtent = vertExtent * cam.aspect; // Horizontal size of the camera
        }
        else
        {
            Debug.LogWarning("This script is designed for orthographic cameras.");
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
