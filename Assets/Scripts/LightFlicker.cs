using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light flickerLight;
    float intensity = 0f;

    public float interval = 0f;
    void Start()
    {
        intensity = flickerLight.intensity;
        StartCoroutine(flicker());
    }

    IEnumerator flicker()
    {
        float timeElapsed = 0f;

        while (true)
        {
            if (timeElapsed <= interval)
            {
                timeElapsed += Time.deltaTime;
                yield return null;
                continue;
            }

            timeElapsed = 0;
            flickerLight.intensity = intensity * Random.Range(0f, 1f);
        }
    }
}
