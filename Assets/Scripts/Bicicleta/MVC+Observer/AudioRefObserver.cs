using System;
using UnityEngine;

public class AudioRefObserver : MonoBehaviour
{
    public static event Action<AudioSource> OnGetReference;
    private static AudioSource audioSource;

    private AudioRefObserver() { }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void SetReference()
    {
        OnGetReference?.Invoke(audioSource);
    }
}
