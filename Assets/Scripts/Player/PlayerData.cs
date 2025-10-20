using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int score = 0;
    public int Score { get { return score; } }
    public UpdateScore scoreBoard;

    void Start()
    {
        scoreBoard = FindFirstObjectByType<UpdateScore>();
        if (scoreBoard == null)
        {
            Debug.LogError("ScoreBoard not found in the scene.");
        } else
        {
            scoreBoard.UpdateScoreText(score);
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
