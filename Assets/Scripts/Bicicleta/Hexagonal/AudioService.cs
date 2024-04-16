using UnityEngine;

public class AudioService : IAudioService
{
    private AudioSource audioSource;

    public void TocarSom(AudioClip _clip)
    {
        if (audioSource == null)
            audioSource = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioSource>();

        audioSource.clip = _clip;
        audioSource.Play();
    }
}

public interface IAudioService
{
    void TocarSom(AudioClip _clip);
}