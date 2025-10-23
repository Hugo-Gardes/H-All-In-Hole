using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    private float xp = 0f;
    private int score = 0;
    public int Score { get { return score; } }
    public float Xp { get { return xp; } }

    public UpdateScore scoreBoard;
    public TextMeshPro xpText;

    void Start()
    {
        scoreBoard = FindFirstObjectByType<UpdateScore>();
        if (scoreBoard == null)
        {
            Debug.LogError("ScoreBoard not found in the scene.");
        }
        else
        {
            scoreBoard.UpdateScoreText(score);
        }

        ResetScore();
        ResetXp();
    }

    public void AddXp(float amount)
    {
        xp += amount;
        if (xpText != null)
        {
            if (xp % 1 == 0)
            {
                xpText.text = ((int)xp).ToString();
            }
            else
            {
                xpText.text = xp.ToString("F2");
            }
        }
    }

    public void ResetXp()
    {
        xp = 0f;
        if (xpText != null)
        {
            if (xp % 1 == 0)
            {
                xpText.text = ((int)xp).ToString();
            }
            else
            {
                xpText.text = xp.ToString("F2");
            }
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        if (scoreBoard != null)
        {
            scoreBoard.UpdateScoreText(score);
        }
    }

    public void ResetScore()
    {
        score = 0;
        if (scoreBoard != null)
        {
            scoreBoard.UpdateScoreText(score);
        }
    }
}
