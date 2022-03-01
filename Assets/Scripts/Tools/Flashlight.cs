using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Tool
{
    [Header("References")]
    public Light lightSource;
    public AudioSource audioSource;
    public GameObject hand;
    public static bool on = false;
    // public float power = 1f;
    // public float wasteRate = 1f;
    // private float initialIntensity;

    // Start is called before the first frame update
    void Start()
    {
        lightSource.gameObject.SetActive(false);
        // initialIntensity = lightSource.intensity;
    }

    void Update()
    {
        // if (on)
        //     power -= wasteRate * Time.deltaTime;
        // else
        //     power += wasteRate * Time.deltaTime;

        // power = Mathf.Clamp(power, 0f, 1f);

        // lightSource.intensity = initialIntensity * power;

        // if (power <= 0)
        // {
        //     on = false;
        //     lightSource.gameObject.SetActive(on);
        // }
    }

    void OnEnable()
    {
        GlobalInput.masterInput.Mouse.LeftClick.performed += switchLight;
        hand.SetActive(true);
    }

    void OnDisable()
    {
        GlobalInput.masterInput.Mouse.LeftClick.performed -= switchLight;
        hand.SetActive(false);
    }

    void switchLight(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!GlobalInput.isGamePaused()) {
            on = !on;
            audioSource.Play();
            lightSource.gameObject.SetActive(on);
        }
    }
}
