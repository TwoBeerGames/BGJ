using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;

public class MouseSenseSlider : MonoBehaviour
{
    public PlayerController playerController;
    private SliderManager slider;

    void Start() {
        slider = gameObject.GetComponent<SliderManager>();
        slider.mainSlider.value = playerController.mouseSensivity;
    }

    public void handleMouseSense() {
        playerController.mouseSensivity = slider.mainSlider.value;
    }
}
