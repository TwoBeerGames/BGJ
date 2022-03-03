using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweepo : MonoBehaviour
{
    public SimpleTurn turn;
    public AudioSource audioSource;
    bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        turn.gameObject.SetActive(false);
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
        turn.gameObject.SetActive(true);
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        turn.gameObject.SetActive(false);
    }
}
