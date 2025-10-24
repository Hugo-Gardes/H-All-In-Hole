using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Cursor : MonoBehaviour
{
    public GameObject[] possiblePositions;
    public GameObject Image;
    public TMP_Text LevelText;
    public Buttons scriptButtons;
    private int currentPositionIndex = 0;
    private int LevelCount = 1;

    void Start()
    {
        if (PlayerPrefs.HasKey("CursorPositionIndex"))
        {
            currentPositionIndex = PlayerPrefs.GetInt("CursorPositionIndex");
        }
        else
        {
            PlayerPrefs.SetInt("CursorPositionIndex", currentPositionIndex);
        }

        if (PlayerPrefs.HasKey("CursorLevelCount"))
        {
            LevelCount = PlayerPrefs.GetInt("CursorLevelCount");
        }
        else
        {
            PlayerPrefs.SetInt("CursorLevelCount", LevelCount);
        }
        UpdateText();
        UpdateCursorPosition();
        switch (possiblePositions[currentPositionIndex].name[..2])
        {
            case "z1":
                scriptButtons.sceneName = "zone1";
                break;
            default:
                break;
        }
    }

    private void UpdateText()
    {
        LevelText.text = LevelCount.ToString();
    }

    private void UpdateCursorPosition()
    {
        if (currentPositionIndex < 0 || currentPositionIndex >= possiblePositions.Length)
        {
            currentPositionIndex = 0;
            PlayerPrefs.SetInt("CursorPositionIndex", currentPositionIndex);
        }
        Image.transform.position = possiblePositions[currentPositionIndex].transform.position;
    }

    // temp
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            LevelCount++;
            UpdateText();
            currentPositionIndex++;
            UpdateCursorPosition();
        }
    }
}
