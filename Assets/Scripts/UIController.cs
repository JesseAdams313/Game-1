using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject selectLevelPanel;
    public GameObject optionPanel;

    public void ToggleSelectLevelPanel()
    {
        bool isActive = selectLevelPanel.activeSelf;
        selectLevelPanel.SetActive(!isActive);
    }

    public void ToggleOptionPanel() {
        bool isActive = optionPanel.activeSelf;
        optionPanel.SetActive(!isActive);
    }


    //////////////
    //Slider Place Holders
    /////////////

    //Set Gamma / Brightness
    public void SetGamma(float value)
    {
        Debug.Log("Gamma: " + value);
    }

    //Set Music Volume
    public void SetMusicVolume(float value)
    {
        Debug.Log("Music Volume: " + value);
    }

    //Set SFX Volume

    public void SetSFXVolume(float value)
    {
        Debug.Log("SFX Volume: " + value);
    }

    //Toggle Fullscreen
    public void ToggleFullscreen(bool value)
    {
        Debug.Log("Fullscreen: " + value);
    }

    //Set Resolution
    public void SetResolution(int value)
    {
        Debug.Log("Resolution: " + value);
    }



}
