using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Tool
{
    [Header("References")]
    public Light lightSource;
    [Header("Properties")]
    public bool on = false;
    public AudioSource audioSource;
    public float power = 1f;
    public float wasteRate = 1f;
    private float initialIntensity;

    // Start is called before the first frame update
    void Start()
    {
        lightSource.gameObject.SetActive(false);
        initialIntensity = lightSource.intensity;

        GlobalInput.masterInput.Mouse.LeftClick.performed += ctx =>
        {

        };
    }

    void Update()
    {
        if (on)
            power -= wasteRate * Time.deltaTime;
        else
            power += wasteRate * Time.deltaTime;

        power = Mathf.Clamp(power, 0f, 1f);

        lightSource.intensity = initialIntensity * power;

        if (power <= 0)
        {
            on = false;
            lightSource.gameObject.SetActive(on);
        }



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
<<<<<<< HEAD
        if (!GlobalInput.isGamePaused()) {
            on = !on;
            lightSource.gameObject.SetActive(on);
        }
=======
        on = !on;
        audioSource.Play();
        lightSource.gameObject.SetActive(on);
>>>>>>> 6e962b5d411e35f651efcfea6aef49b1a2394920
    }
}
