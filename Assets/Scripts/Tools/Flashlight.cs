using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Tool
{
    [Header("References")]
    public Light lightSource;
    [Header("Properties")]
    public bool on = false;
    // Start is called before the first frame update
    void Start()
    {

        lightSource.gameObject.SetActive(false);

        GlobalInput.masterInput.Mouse.LeftClick.performed += ctx =>
        {

        };
    }

    void OnEnable()
    {
        GlobalInput.masterInput.Mouse.LeftClick.performed += switchLight;
    }

    void OnDisable()
    {
        GlobalInput.masterInput.Mouse.LeftClick.performed -= switchLight;
    }

    void switchLight(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        on = !on;
        lightSource.gameObject.SetActive(on);
    }
}
