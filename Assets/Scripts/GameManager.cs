using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public GameObject gameUI;

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0;
    }

    public void Win()
    {
        winScreen.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
