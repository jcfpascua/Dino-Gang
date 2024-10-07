using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField]
    public void ChangeToLevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }
    [SerializeField]
    public void ChangeToSettings()
    {
        SceneManager.LoadScene("Settings Scene");
    }
    [SerializeField]
    public void ChangeTo1_1() {
        SceneManager.LoadScene("Stage 1-01");
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Pitfall")) {
            Debug.Log("I'M BACK IN THE FUCKING BUILDING AGAIN");
        } else if (other.gameObject.CompareTag("Finish")) {
            Debug.Log("martha i'm coming home sweetie");
        }
    }
}
