using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float acceleration = 10f;

    private Rigidbody rb;
    private Vector3 inputDirection;
    private Vector3 currentVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal"); // A/D
        float inputZ = Input.GetAxis("Vertical");   // W/S

        // Movement relative to world (or camera — optional)
        inputDirection = new Vector3(inputX, 0f, inputZ).normalized;
    }

    void FixedUpdate()
    {
        // Target velocity in world space (no rotation)
        Vector3 targetVelocity = inputDirection * moveSpeed;

        // Smooth acceleration
        Vector3 velocityChange = Vector3.Lerp(rb.linearVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);

        // Keep gravity Y velocity
        rb.linearVelocity = new Vector3(velocityChange.x, rb.linearVelocity.y, velocityChange.z);
    }
}
