using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : Tool
{
    public AudioSource audioSource;
    public AudioClip beep;

    void OnEnable()
    {
        ScanInterval.ping.AddListener(doPing);
    }

    void doPing()
    {
        audioSource.PlayOneShot(beep);
    }

    void OnDisable()
    {
        ScanInterval.ping.RemoveListener(doPing);
    }
}
