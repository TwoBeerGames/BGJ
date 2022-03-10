using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSilencer : MonoBehaviour
{
    public float inOut = 1f;
    public int duration = 4;
    public bool processed = false;
    public AudioMixer mixer;
    private void OnTriggerEnter(Collider other)
    {
        if (!processed && other.gameObject.layer == 7)
        {
            StartCoroutine(silence());
            processed = !processed;
        }
    }

    IEnumerator silence()
    {
        float timeElapsed = 0f;
        float progress = 0;
        float initialVolume = 0f;
        mixer.GetFloat("MusicVolume", out initialVolume);

        while (timeElapsed <= inOut)
        {
            timeElapsed += Time.deltaTime;
            progress = timeElapsed / inOut;

            mixer.SetFloat("MusicVolume", -80 * progress);

            yield return null;
        }

        timeElapsed = 0f;
        mixer.SetFloat("MusicVolume", -80);

        yield return new WaitForSeconds(duration);

        while (timeElapsed <= inOut)
        {
            timeElapsed += Time.deltaTime;
            progress = timeElapsed / inOut;

            mixer.SetFloat("MusicVolume", -80 * (1 - progress));

            yield return null;
        }

        mixer.SetFloat("MusicVolume", initialVolume);
    }
}
