using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseButton;
    public GameObject ResumeButton;

    public GameObject Resume;
    public GameObject ToSettings;

    public GameObject Settings;
    public GameObject ToMenuButton;

    public GameObject Menu;

    public GameObject General;

 void Start()
    {
        ResumeButton.SetActive(false);
    }
    public void Pause()
    {
        PauseButton.SetActive(true);
        ResumeButton.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Play()
    {
        Time.timeScale = 1f;
        PauseButton.SetActive(false);
        ResumeButton.SetActive(false);
    }

    public void ToSetting()
    {
        ToSettings.SetActive(true);
        Resume.SetActive(false);
        Settings.SetActive(false);
        Menu.SetActive(false);
        General.SetActive(false);
    }

    public void FromSetting()
    {
        ToSettings.SetActive(false);
        Resume.SetActive(true);
        Settings.SetActive(true);
        Menu.SetActive(true);
        General.SetActive(true);
    }

    public void ToMenu() {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
}
}
