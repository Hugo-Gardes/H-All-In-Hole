using UnityEngine;
using UnityEngine.InputSystem;

public class HandleBack : MonoBehaviour
{
    public GameObject menuToOpen;

    public void openMenu()
    {
        if (menuToOpen != null)
        {
            menuToOpen.SetActive(true);
        }
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            openMenu();
        }
    }
}
