using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : Tool
{
    public AudioSource audioSource;
    public AudioClip beep;
    public GameObject hand;

    void OnEnable()
    {
        ScanInterval.ping.AddListener(doPing);
        hand.SetActive(true);
    }

    void doPing()
    {
        audioSource.PlayOneShot(beep);
    }

    void OnDisable()
    {
        ScanInterval.ping.RemoveListener(doPing);
        hand.SetActive(false);
    }
}
