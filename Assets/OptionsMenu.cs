using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    //public Dropdown resolutionDropdown;
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    void Start() 
    {
        resolutions = Screen.resolutions;
        // Clear options first
        resolutionDropdown.ClearOptions();

        // dropdown.AddOptions() takes a list of strings, so we have to loop through the Resolution[] and put the values to the string list

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) 
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) 
            {
                currentResolutionIndex = i;
            }
        }
        // Add new options to the dropdown menu
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex) 
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume) 
    {
        audioMixer.SetFloat("Volume", volume);
        //Debug.Log(volume);
    }

    public void SetQuality(int qualityIndex) 
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullscreen) 
    {
        Screen.fullScreen = isFullscreen;
    }
}
