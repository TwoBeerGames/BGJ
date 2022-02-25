using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;

public class VolumeSliderManager : MonoBehaviour
{
    public AudioManager audioManager;
    public void handleMasterVolume() {
        SliderManager slider = gameObject.GetComponent<SliderManager>();
        audioManager.setMasterVolume(slider.mainSlider.value);
    }

    public void handleSfxVolume() {
        SliderManager slider = gameObject.GetComponent<SliderManager>();
        audioManager.setSfxVolume(slider.mainSlider.value);
    }

    public void handleMusicVolume() {
        SliderManager slider = gameObject.GetComponent<SliderManager>();
        audioManager.setMusicVolume(slider.mainSlider.value);
    }
}
