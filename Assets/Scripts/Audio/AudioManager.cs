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
    private AudioSource loopSource1;
    private AudioSource loopSource2;
    private AudioSource sfxSource;
    #endregion


    private void Awake()
    {
        loopSource1 = this.gameObject.AddComponent<AudioSource>();
        loopSource2 = this.gameObject.AddComponent<AudioSource>();
        sfxSource = this.gameObject.AddComponent<AudioSource>();

        // Assigning audio mixer child to each audio source
        AudioMixer MasterMixer = Resources.Load<AudioMixer>("Master");
        string _MixerGroup1 = "LoopSource1";
        string _MixerGroup2 = "LoopSource2";
        string _MixerGroup3 = "SFX";
        loopSource1.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(_MixerGroup1)[0];
        loopSource2.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(_MixerGroup2)[0];
        sfxSource.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(_MixerGroup3)[0];
    }

    // Play one shot audio clips
    public void PlaySFX(AudioClip audioClip, float volume, float pitch)
    {
        sfxSource.volume = volume;
        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(audioClip);
    }

    // Play loop source 1 with option to loop
    public void PlayLoopSource1(AudioClip audioClip, float volume, bool loop = false)
    {
        loopSource1.clip = audioClip;
        loopSource1.volume = volume;
        loopSource1.loop = loop;
        loopSource1.Play();
    }

    // Play loop source 2 with option to loop
    public void PlayLoopSource2(AudioClip audioClip, float volume, bool loop = false)
    {
        loopSource2.clip = audioClip;
        loopSource2.volume = volume;
        loopSource2.loop = loop;
        loopSource2.Play();
    }

    // Stop loop source 1
    public void StopLoopSource1()
    {
        loopSource1.Stop();
    }

    // Stop loop source 2
    public void StopLoopSource2()
    {
        loopSource2.Stop();
    }

    // Pause loop source 1
    public void PauseLoopSource1()
    {
        loopSource1.Pause();
    }

    // Pause loop source 2
    public void PauseLoopSource2()
    {
        loopSource2.Pause();
    }

    // Unpause loop source 1
    public void UnpauseLoopSource1()
    {
        loopSource1.UnPause();
    }

    // Unpause loop source 2
    public void UnpauseLoopSource2()
    {
        loopSource2.UnPause();
    }

    // change loop source 1 volume
    public void LoopSrc1Vol(float volume)
    {
        loopSource1.volume = volume;
    }

    // change loop source 2 volume
    public void LoopSrc2Vol(float volume)
    {
        loopSource2.volume = volume;
    }
}
