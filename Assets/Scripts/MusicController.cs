using UnityEngine;

public class MusicController : MonoBehaviour
{
    [Tooltip("Drag your AudioManager GameObject here")]
    public AudioSource musicSource;

    // Called by Play Button's OnClick event
    public void PlayMusic()
    {
        if (musicSource == null)
        {
            Debug.LogError("AudioSource not assigned to MusicController!");
            return;
        }
        
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    // Called by Stop Button's OnClick event
    public void StopMusic()
    {
        if (musicSource == null) return;
        
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
}
