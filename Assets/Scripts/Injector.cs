using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Injector : Tool
{
    [Header("References")]
    public Text ammoText;
    public Text slashText;
    public Text maxAmmoText;
    
    [Header("Properties")]
    public int maxAmmo = 3;
    public Nullable<int> ammo = null;

    void Start()
    {
        GlobalInput.masterInput.Mouse.LeftClick.performed += ctx => Inject();
    }

    void OnEnable() {
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
        // hide Ammo UI
        if (ammoText && slashText && maxAmmoText) {
            changeActiveState(false);
        }
    }

    void Inject() {
        if (ammo > 0) {
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
