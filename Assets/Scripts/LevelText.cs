using System.Collections;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    public GameObject scoreUI;
    public GameObject highScoreUI;
    public GameObject healthUI;
    void Start()
    {
        scoreUI.SetActive(false);
        highScoreUI.SetActive(false);
        healthUI.SetActive(false);
        StartCoroutine(HideText());
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        scoreUI.SetActive(true);
        highScoreUI.SetActive(true);
        healthUI.SetActive(true);
    }
}
