using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource musicAudioSource;
    public AudioSource fxAudioSource;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(Sound sound)
    {
        if (sound.soundType == Sound.SoundType.MUSIC)
        {
            PlayMusic(sound);
        }
        else if (sound.soundType == Sound.SoundType.FX)
        {
            PlayFxSound(sound);
        }
    }

        private void PlayMusic(Sound sound)
        {
        musicAudioSource.clip = sound.clip;
        musicAudioSource.volume = sound.volume;
        musicAudioSource.loop = sound.loop;

        musicAudioSource.Play();
        }

    private void PlayFxSound(Sound sound)
    {
        fxAudioSource.clip = sound.clip;
        fxAudioSource.volume = sound.volume;
        fxAudioSource.loop = sound.loop;

        fxAudioSource.Play();
    }

    }
