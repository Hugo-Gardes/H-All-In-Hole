using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public string sceneName;

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene(sceneName);
    }
}
