using UnityEngine;
using TMPro;

using UnityEngine.UI;

public class ButtonsSwitchMenu : MonoBehaviour
{
    public Button[] buttonsMenus;

    private Button currentButton;
    private GameObject currentMenu;

    void Start()
    {
        buttonsMenus[0].onClick.Invoke();
        buttonsMenus[0].Select();
    }

    public void clicked(GameObject menu)
    {
        if (currentMenu != null)
        {
            currentMenu.SetActive(false);
        }
        currentMenu = menu;
        menu.SetActive(true);
    }

    public void disable(Button button)
    {
        if (currentButton != null)
        {
            currentButton.interactable = true;
        }
        currentButton = button;
        button.interactable = false;
    }
}
