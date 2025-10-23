using UnityEngine;
using UnityEngine.InputSystem;

public class HandleBack : MonoBehaviour
{
    public GameObject menuToOpen;

    private void openMenu()
    {
        menuToOpen.SetActive(true);
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
