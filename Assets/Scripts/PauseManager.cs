using System.Collections;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject gameUI;
    public GameObject winScreen;
    public GameObject gameOverScreen;
    
    bool canPause = false;
    bool paused = false;

    void Start()
    {
        StartCoroutine(EnablePause());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            if (winScreen.activeSelf || gameOverScreen.activeSelf)
                return;
            
            if (paused)
                Resume();
            else
                Pause();
        }
    }

    IEnumerator EnablePause()
    {
        yield return new WaitForSecondsRealtime(3f);
        canPause = true;
    }

    public void Pause()
    {
        paused = true;
        pauseScreen.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0;
    }
        
    public void Resume()
    {
        paused = false;
        pauseScreen.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
    }
}
