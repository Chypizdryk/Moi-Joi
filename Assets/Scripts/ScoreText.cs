using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public static ScoreText Instance;

    public TMP_Text scoreText;
    
    public TMP_Text highScoreText;

    public int score = 0;

    void Awake()
    {
        Instance = this;
        
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
    
    public void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }
}