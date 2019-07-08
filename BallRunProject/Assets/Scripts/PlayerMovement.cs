using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb; // Rigidbody component reference to the asset named "Player".
    public float ForwardForce; // A float variable to add forward force.
    public float SidewaysForce; // A float variable to add force to either left or right.
    public float BackwardsForce; // A float variable to add backwards force. 

    // "FixedUpdate" because it is messing with physics
    void FixedUpdate()
    { 
        // Get user input and add force to the direction
        // the user wants to go to.
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, ForwardForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0, 0, -BackwardsForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        

        if (rb.position.y < -1f)
        { 
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
