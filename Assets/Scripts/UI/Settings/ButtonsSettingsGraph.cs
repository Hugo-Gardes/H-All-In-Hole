using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class ButtonsSettings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public ConfirmationScript confirmationScript;
    public GameObject confirmationObject;
    public Toggle fullscreenToggle;

    private Resolution ActulalResolution;
    private List<string> options = new();
    private bool isFirst = true;
    private bool isFullScreen = false;

    void Start()
    {

        if (resolutionDropdown == null)
        {
            resolutionDropdown = GetComponentInChildren<TMP_Dropdown>();
        }

        resolutionDropdown.ClearOptions();
        foreach (Resolution resolution in Screen.resolutions)
        {
            options.Add(resolution.ToString());
        }
        resolutionDropdown.AddOptions(options);
        ActulalResolution = Screen.currentResolution;
        resolutionDropdown.value = options.IndexOf(ActulalResolution.ToString());
        isFullScreen = Screen.fullScreen;
        fullscreenToggle.isOn = isFullScreen;
    }

    private void UpdateResolutionConfirmed()
    {
        Resolution selectedResolution = Screen.resolutions[resolutionDropdown.value];
        ActulalResolution = selectedResolution;
    }

    private void UpdateResolutionCanceled()
    {
        Screen.SetResolution(ActulalResolution.width, ActulalResolution.height, Screen.fullScreen);
        resolutionDropdown.value = options.IndexOf(ActulalResolution.ToString());
    }

    public void UpdateFullscreen()
    {
        isFullScreen = fullscreenToggle.isOn;
        Screen.fullScreen = isFullScreen;
    }

    public void UpdateResolution()
    {
        Resolution selectedResolution;

        if (isFirst)
        {
            isFirst = false;
            return;
        }

        selectedResolution = Screen.resolutions[resolutionDropdown.value];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);

        confirmationObject.SetActive(true);
        confirmationScript.confirmation(UpdateResolutionConfirmed, UpdateResolutionCanceled);
    }
}
