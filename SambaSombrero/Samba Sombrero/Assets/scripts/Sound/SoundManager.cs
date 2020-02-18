using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    [SerializeField]
    private AudioSource fxAudioSource;
    [SerializeField]
    private AudioSource musicAudioSource;
    [SerializeField]
    private AudioMixer gameAudio;

    private bool soundMuted;

    private void Start()
    {
        soundMuted = false;
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        fxAudioSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicAudioSource.clip = clip;
        musicAudioSource.Play();
    }

    public bool GetSoundMuted()
    {
        return soundMuted;
    }

    public void SetSoundMuted(bool value)
    {
        soundMuted = value;
        gameAudio.SetFloat("FXVolume", soundMuted ? -80f : 0f);
        gameAudio.SetFloat("MusicVolume", soundMuted ? -80f : 0f);
    }
}
