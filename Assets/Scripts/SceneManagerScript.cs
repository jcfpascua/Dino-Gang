using System.Collections;
using System.Collections.Generic;
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
}
