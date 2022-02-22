using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InjectorTobias : Tool
{
    [Header("References")]
    public Text ammoText;
    public Text slashText;
    public Text maxAmmoText;
    
    [Header("Properties")]
    public int maxAmmo = 3;
    public Nullable<int> ammo = null;
    public float healAmount = 0.25f;

    void OnEnable() {
        // Event
        GlobalInput.masterInput.Mouse.LeftClick.performed += Inject;

        // Ammo Handling
        if (ammoText && slashText && maxAmmoText) {
            // Show Ammo UI
            changeActiveState(true);

            // Set Ammo values
            if (ammo == null) ammo = maxAmmo;
            ammoText.text = ammo.ToString();
            maxAmmoText.text = maxAmmo.ToString();
        }
    }

    void OnDisable() {
        // Event
        GlobalInput.masterInput.Mouse.LeftClick.performed -= Inject;

        // Hide Ammo UI
        if (ammoText && slashText && maxAmmoText) {
            changeActiveState(false);
        }
    }

    void Inject(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (ammo > 0) {
            // StressLevel
            StressLevel.inst.stressLevel -= healAmount;
            StressLevel.inst.stressLevel = Mathf.Clamp(StressLevel.inst.stressLevel, 0f, 1f);

            // Ammo Handling
            ammo--;
            ammoText.text = ammo.ToString();
        }
    }

    void changeActiveState(bool state) {
        ammoText.gameObject.SetActive(state);
        slashText.gameObject.SetActive(state);
        maxAmmoText.gameObject.SetActive(state);
    }
}
