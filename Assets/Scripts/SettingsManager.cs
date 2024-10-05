using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel; // The popup panel
    public Button settingsButton;    // The button to show the popup
    public Button exitButton;
    public Slider volumeSlider;      // Slider to control master volume
    public TMP_Dropdown windowSizeDropdown;  // Dropdown to control window size

    private bool isPanelOpen = false; // Keep track of popup state

    void Start()
    {
        // Initially, hide the settings panel
        settingsPanel.SetActive(false);

        // Add a listener to the button to handle showing the panel
        settingsButton.onClick.AddListener(ToggleSettingsPanel);
        exitButton.onClick.AddListener(CloseSettingsPanel);

        // Set up listeners for the settings controls
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        windowSizeDropdown.onValueChanged.AddListener(ChangeWindowMode);
    }

    void ToggleSettingsPanel()
    {
        isPanelOpen = !isPanelOpen;
        settingsPanel.SetActive(isPanelOpen);
    }

    void CloseSettingsPanel()
    {
        isPanelOpen = false;
        settingsPanel.SetActive(false); // Hide the panel
    }

    void ChangeVolume(float value)
    {
        AudioListener.volume = value;
    }

    void ChangeWindowMode(int index)
    {
        
        switch (index)
        {
            case 0:
                Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
                break;
        }
    }
    void View()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);

    }
}
