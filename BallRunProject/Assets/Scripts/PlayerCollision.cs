using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // This function is called when we hit an object
    // Get information about the collision and call it "collisionInfo"

    private void OnCollisionEnter(Collision collisionInfo)
    {
        // We check if the object we collided with has a tag called "Obstacle"
        if (collisionInfo.collider.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
