using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public static ScoreText Instance;

    public TMP_Text scoreText;

    int score = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
}