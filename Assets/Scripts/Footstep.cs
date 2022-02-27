using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    public AudioClip[] steps;
    public AudioSource audioSource;
    [Range(-1, 1)]
    public float currentPan = -.5f;
    // Start is called before the first frame update

    public void Start()
    {
        audioSource.panStereo = currentPan;
    }
    public void PlayFootStep()
    {
        audioSource.panStereo = currentPan;
        audioSource.PlayOneShot(steps[Random.Range(0, steps.Length)]);
        currentPan *= -1;
    }
}
