using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLog : MonoBehaviour, IInteractable
{
    public bool canInteract { get; set; } = true;
    AudioSource audioSource;
    public GameObject uiElement;
    public ParticleSystem süs;
    public Monitor monitor;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayerController.die.AddListener(stopAudio);
    }

    public void interact()
    {
        if (canInteract)
        {

            StoryProgression.progressionUpdate.Invoke();
            canInteract = false;
            audioSource.Play();
            monitor.typeText();
            süs.Stop();
            uiElement.SetActive(false);
            StartCoroutine(blindMonster());
        }
    }

    void stopAudio()
    {
        audioSource.Stop();
    }

    public void reset()
    {
        canInteract = true;
        süs.Play();
        uiElement.SetActive(true);
    }

    IEnumerator blindMonster()
    {

        MonsterController.inst.gameObject.SetActive(false);

        while (audioSource.isPlaying)
        {
            yield return null;
        }

        MonsterController.inst.gameObject.SetActive(true);
    }
}
