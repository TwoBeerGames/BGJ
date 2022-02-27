using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class Fader : MonoBehaviour
{
    public static Fader inst;
    public PostProcessVolume volume;
    AutoExposure auto;
    // Start is called before the first frame update
    void Awake()
    {
        inst = this;
        volume.profile.TryGetSettings<AutoExposure>(out auto);
    }

    public void goBlack(float time)
    {
        StartCoroutine(fade(0f, 9f, time));
    }

    public void noBlack(float time)
    {
        StartCoroutine(fade(9f, 0f, time));
    }

    IEnumerator fade(float from, float to, float time)
    {
        float timeElapsed = 0f;
        float progress = 0f;

        while (timeElapsed < time)
        {
            timeElapsed += Time.deltaTime;
            progress = timeElapsed / time;

            auto.minLuminance.value = Mathf.Lerp(from, to, progress);
            yield return null;
            continue;
        }

        auto.maxLuminance.value = to;
    }

    public void clear()
    {
        auto.maxLuminance.value = 0;
    }
}
