using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    const string mixerMaster = "MasterVolume";
    const string mixerSfx = "SFXVolume";
    const string mixerMusic = "MusicVolume";

    public void setMasterVolume(float value) {
        //evtl Mathf.Log10(value) * 20);
        mixer.SetFloat(mixerMaster, value);
    }

    public void setSfxVolume(float value) {
        mixer.SetFloat(mixerSfx, value);
    }

    public void setMusicVolume(float value) {
        mixer.SetFloat(mixerMusic, value);
    }
}
