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
            on = !on;
            lightSource.gameObject.SetActive(on);
        };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
