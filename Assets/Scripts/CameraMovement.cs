using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public float smoothSpeed = 0.5f; // Smoothness of camera movement

    private Vector3 offset; // Offset between camera and player

    private void Start()
    {
        // Calculate the initial offset between the camera and player
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // Calculate the target position for the camera
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
