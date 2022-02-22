using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectorTobias : Tool
{

    public float healAmount = 0.25f;
    // Start is called before the first frame update
    void OnEnable()
    {
        GlobalInput.masterInput.Mouse.LeftClick.performed += reduceStress;
    }

    void OnDisable()
    {
        GlobalInput.masterInput.Mouse.LeftClick.performed -= reduceStress;
    }

    void reduceStress(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        StressLevel.inst.stressLevel -= .25f;

        StressLevel.inst.stressLevel = Mathf.Clamp(StressLevel.inst.stressLevel, 0f, 1f);
    }
}
