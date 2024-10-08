using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCollision : MonoBehaviour
{
    public float fallThreshold = -8f; // Y position threshold for losing

    void Update()
    {
        // Check if player falls below fallThreshold
        if (transform.position.y <= fallThreshold)
        {
            SceneManager.LoadScene("Lose Scene");  // Load the lose scene
        }
    }

    // Trigger when player collides with certain objects
    public void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player reaches the finish line
        if (other.CompareTag("Finish"))  // Make sure the finish line has the tag "Finish"
        {
            SceneManager.LoadScene("Win Scene");  // Load the win scene
        }
        // Check if the player collides with a pit or spike
        else if (other.CompareTag("Deadly")) // Ensure pits and spikes have these tags
        {
            SceneManager.LoadScene("Lose Scene");  // Load the lose scene
        }
    }
}
