using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject settingsMenu;
    public string sceneName;

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnSettingsButtonPressed()
    {
        settingsMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
