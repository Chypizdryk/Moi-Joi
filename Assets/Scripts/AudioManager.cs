using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public AudioSource AudioSource;

    private void Awake()
    {
        instance = this;
    }

    public void Play(AudioClip clip)
    {
        AudioSource.PlayOneShot(clip);
    }
}
