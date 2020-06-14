using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance != null)
            {
                return instance;
            }

            GameObject managerObj = new GameObject("AudioManager");
            instance = managerObj.AddComponent<AudioManager>();
            return instance;
        }
    }

    // Initialized audio sources for manager
    #region
    private AudioSource musicSource;
    private AudioSource sfxSource;
    #endregion


    private void Awake()
    {
        musicSource = this.gameObject.AddComponent<AudioSource>();
        sfxSource = this.gameObject.AddComponent<AudioSource>();

        // Assigning audio mixer child to each audio source
        AudioMixer MasterMixer = Resources.Load<AudioMixer>("Master");
        string _MixerGroup1 = "Music";
        string _MixerGroup2 = "SFX";
        musicSource.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(_MixerGroup1)[0];
        sfxSource.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(_MixerGroup2)[0];
    }

    // Play one shot audio clips
    public void PlaySFX(AudioClip audioClip, float volume, float pitch)
    {
        sfxSource.volume = volume;
        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(audioClip);
    }

    // Play music with option to loop
    public void PlayMusic(AudioClip audioClip, float volume, bool loop = false)
    {
        musicSource.clip = audioClip;
        musicSource.volume = volume;
        musicSource.loop = loop;
        musicSource.Play();
    }

    // Stop Music
    public void StopMusic()
    {
        musicSource.Stop();
    }

    // Pause Music
    public void PauseMusic()
    {
        musicSource.Pause();
    }

    // change music volume
    public void MusicVol(float volume)
    {
        musicSource.volume = volume;
    }
}
