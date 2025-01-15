using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource audioSrc => GetComponent<AudioSource>();

    public void PlaySound(AudioClip clip, float volume = 1f, bool destroyed = false, bool loop = false)
    {
        if (destroyed)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position, volume);
        }
        else
        {
            audioSrc.loop = loop;   
            audioSrc.clip = clip;   
            audioSrc.volume = volume;   
            audioSrc.Play();   
        }
    }

    public void StopSound()
    {
        audioSrc.Stop();
    }
}