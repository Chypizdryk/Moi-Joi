using System.Collections;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    public GameObject scoreUI;
    public GameObject highScoreUI;
    public GameObject healthUI;
    public GameObject ButtonsUI;
    public GameObject JoystickUI;
    
    void Start()
    {
        scoreUI.SetActive(false);
        highScoreUI.SetActive(false);
        healthUI.SetActive(false);
        ButtonsUI.SetActive(false);
        JoystickUI.SetActive(false);
        StartCoroutine(HideText());
    }

    IEnumerator HideText()
    {
        yield return new WaitForSecondsRealtime(3f);
        gameObject.SetActive(false);
        scoreUI.SetActive(true);
        highScoreUI.SetActive(true);
        healthUI.SetActive(true);
        ButtonsUI.SetActive(true);
        JoystickUI.SetActive(true);
    }
}
