using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         // Assign your bunny here
    public Vector3 offset = new Vector3(0, 5, -10); // Height and distance behind bunny
    public float followSpeed = 5f;   // Smooth following
    public float rotationSpeed = 5f; // Smooth rotation

    void LateUpdate()
    {
        if (target == null) return;

        // Desired position with offset relative to the target's rotation
        Vector3 desiredPosition = target.position + target.rotation * offset;

        // Smoothly move the camera
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Smoothly rotate the camera to match the bunny's direction
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }
}
