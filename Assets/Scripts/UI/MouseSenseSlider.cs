using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;

public class MouseSenseSlider : MonoBehaviour
{
    public PlayerController playerController;

    public void handleMouseSense() {
        SliderManager slider = gameObject.GetComponent<SliderManager>();
        playerController.mouseSensivity = slider.mainSlider.value;
    }
}
