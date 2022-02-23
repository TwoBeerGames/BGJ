using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;


public class StressLevel : MonoBehaviour
{

    public static StressLevel inst;
    public PostProcessVolume volume;
    public float rate = .1f;

    [Range(0, 1)]
    public float stressLevel = 0f;

    [Header("Vignette")]

    [Range(0f, 1f)]
    public float start;

    [Range(0f, 1f)]
    public float end;
    public float oscillationMultiplicator = 1f;
    Color currentColor = new Color(0, 0, 0);
    Vignette vin;

    public void Start()
    {
        inst = this;
        volume.profile.TryGetSettings<Vignette>(out vin);
        StartCoroutine(stressVisualizer());
    }

    IEnumerator stressVisualizer()
    {
        float timeElapsed = 0f;

        while (true)
        {
            timeElapsed += Time.deltaTime;

            vin.intensity.value = start + (Remap(Mathf.Sin(timeElapsed * oscillationMultiplicator * stressLevel), -1f, 1f, 0, 1) * (end - start));

            yield return null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        stressLevel += rate * Time.deltaTime;

        currentColor.r = 1 - stressLevel;
        currentColor.g = 1 - stressLevel;
        currentColor.b = 1 - stressLevel;

        vin.color.value = currentColor;

        stressLevel = Mathf.Clamp(stressLevel, 0f, 1f);

        if (stressLevel >= 1f)
            die();
    }

    void die()
    {

    }

    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

}
