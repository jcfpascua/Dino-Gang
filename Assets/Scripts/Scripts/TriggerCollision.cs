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

    // Trigger when player finishes the level (e.g., collides with end point)
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))  // Make sure the finish line has the tag "Finish"
        {
            SceneManager.LoadScene("Win Scene");  // Load the win scene
        }
    }
}