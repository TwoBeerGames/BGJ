using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InjectorTobias : Tool
{
    [Header("References")]
    public GameObject icon;
    public GameObject ammoText;
    public GameObject seperator;
    public GameObject maxAmmoText;
    
    [Header("Properties")]
    public int maxAmmo = 3;
    public Nullable<int> ammo = null;
    public float healAmount = 0.25f;

    void OnEnable() {
        // Event
        GlobalInput.masterInput.Mouse.LeftClick.performed += Inject;

        // Ammo Handling
        if (ammoText && seperator && maxAmmoText) {
            // Show Ammo UI
            changeActiveState(true);

            // Set Ammo values
            if (ammo == null) ammo = maxAmmo;
            ammoText.GetComponent<TMPro.TextMeshProUGUI>().text = ammo.ToString();
            maxAmmoText.GetComponent<TMPro.TextMeshProUGUI>().text = maxAmmo.ToString();
        }
    }

    void OnDisable() {
        // Event
        GlobalInput.masterInput.Mouse.LeftClick.performed -= Inject;

        // Hide Ammo UI
        if (ammoText && seperator && maxAmmoText) {
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
            ammoText.GetComponent<TMPro.TextMeshProUGUI>().text = ammo.ToString();
        }
    }

    void changeActiveState(bool state) {
        icon.SetActive(state);
        ammoText.SetActive(state);
        seperator.SetActive(state);
        maxAmmoText.SetActive(state);
    }
}
