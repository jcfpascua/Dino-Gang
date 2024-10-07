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
        SceneManager.LoadScene("Settings");
    }
    [SerializeField]
    public void ChangeTo1_1() {
        SceneManager.LoadScene("Stage 1-01");
    }
    public void ChangeTo1_2() {
        SceneManager.LoadScene("Stage 1-02 SAMPLE");
    }
    public void ChangeTo1_3() {
        SceneManager.LoadScene("Stage 1-03 SAMPLE");
    }
}