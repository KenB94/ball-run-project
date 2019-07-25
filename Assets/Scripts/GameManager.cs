using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false; // Checks to see if the game has ended
    public float restartDelay = 3f; // The time delay before the game restarts after game over.
    public PlayerMovement movement; // A reference to the PlayerMovement script
    public GameObject completeLevelUI; // A reference to the canvas panel to display the message "Level Complete"

    public void CompleteLevel()
    {
        Debug.Log("LEVEL COMPLETE!");
        completeLevelUI.SetActive(true);
    }

    /**
     * This function is called when the player hits an object
     * or when the player falls off the platform
     * */
    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            movement.enabled = false;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }

    // Restarts the game
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
