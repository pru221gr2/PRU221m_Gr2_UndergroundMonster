using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicSource, sfxSource;
    [SerializeField]
    private Sound[] musicSounds, sfxSounds;
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance)
                return instance;

            instance = FindObjectOfType<AudioManager>();

            if (instance)
                return instance;

            return instance = new GameObject(nameof(AudioManager), typeof(AudioSource))
                .AddComponent<AudioManager>();
        }
    }


    private void Awake()
    {
        if (instance && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        // lazy initialization of AudioSource component
        if (!sfxSource)
        {
            if (!TryGetComponent<AudioSource>(out sfxSource))
            {
                sfxSource = gameObject.AddComponent<AudioSource>();
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("Not Found Music");
        }
        else
        {
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }

    private void Start()
    {
        PlayMusic("MainTheme");
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSounds, x => x.name == name);
        if (sound == null)
        {
            Debug.Log("Not Found SFX");
        }
        else
        {
            sfxSource.PlayOneShot(sound.clip);
        }
    }

    public void PlaySound(AudioClip audioClip)
    {
        sfxSource.PlayOneShot(audioClip);
    }

    public void MusicVolume(float value)
    {
        musicSource.volume = value;
    }

    public void SfxVolume(float value)
    {
        sfxSource.volume = value;
    }
}