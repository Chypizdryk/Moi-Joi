using UnityEngine;

public class Lives : MonoBehaviour
{
    public GameObject[] hp;
    private int CurrentHP = 5;
    
    public void LoseLife(int lives)
    {
        if (CurrentHP >= 0)
        {
            hp[CurrentHP].SetActive(false);
            CurrentHP--;
        }

    }
}
