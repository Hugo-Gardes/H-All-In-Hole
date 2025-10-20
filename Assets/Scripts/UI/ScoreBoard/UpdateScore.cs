using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    void Start()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
        if (ScoreText == null)
        {
            Debug.LogError("TextMeshProUGUI component not found.");
        }
    }

    public void UpdateScoreText(int score)
    {
        ScoreText.text = "Score: " + score.ToString();
    }
}
