using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [Tooltip("Mouse sensitivity for looking around.")]
    public float sensitivity = 5f;

    [Tooltip("Camera Y rotation limits (X = min, Y = max).")]
    public Vector2 cameraLimit = new Vector2(-90f, 90f);

    private float mouseX, mouseY;
    private Transform playerBody;

    void Start()
    {
        playerBody = transform.parent; // Assumes the camera is a child of the player
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse movement input
        mouseX += Input.GetAxis("Mouse X") * sensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * sensitivity; // Inverted for natural feel
        mouseY = Mathf.Clamp(mouseY, cameraLimit.x, cameraLimit.y);

        // Rotate the player body left/right
        playerBody.rotation = Quaternion.Euler(0f, mouseX, 0f);

        // Rotate the camera up/down
        transform.localRotation = Quaternion.Euler(mouseY, 0f, 0f);
    }
}
