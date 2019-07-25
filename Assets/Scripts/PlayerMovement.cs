using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb; // Rigidbody component reference to the asset named "Player".
    public SphereCollider col;
    public float JumpForce = 1f;
    public float speed = 1f;
    float moveHorizontal;
    float moveVertical;
    Vector3 movement;
    public LayerMask groundLayers;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }

    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce((Vector3.up * JumpForce) * Time.deltaTime, ForceMode.Impulse);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    // "FixedUpdate" because it is messing with physics
    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    // Check if the player is grounded
    private bool isGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 0.9f, groundLayers);
    }

    private void moveCharacter(Vector3 direction)
    {
        rb.AddForce((direction * speed) * Time.deltaTime, ForceMode.VelocityChange);
    }
}
