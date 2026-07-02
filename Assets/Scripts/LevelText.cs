using System.Collections;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    public GameObject scoreUI;
    void Start()
    {
        scoreUI.SetActive(false);
        StartCoroutine(HideText());
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        scoreUI.SetActive(true);
    }
}
