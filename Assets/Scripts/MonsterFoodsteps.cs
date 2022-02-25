using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFoodsteps : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] clips;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playFootstep()
    {
        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
}
