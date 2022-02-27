using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAudio : MonoBehaviour
{
    AudioSource audioSource;
    public float interval;
    public AudioClip[] clips;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(processAudio());
    }

    IEnumerator processAudio()
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
            timeElapsed = 0f;


            audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);

        }
    }
}
