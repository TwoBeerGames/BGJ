using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweepo : MonoBehaviour
{
    public GameObject turn;
    public AudioSource audioSource;
    public bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        turn.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!done)
        {
            StartCoroutine(boo());
            done = true;
        }
    }



    IEnumerator boo()
    {
        audioSource.Play();
        turn.SetActive(true);
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        turn.SetActive(false);
    }
}
