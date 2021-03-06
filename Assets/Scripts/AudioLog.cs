using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioLog : MonoBehaviour, IInteractable
{
    public bool canInteract { get; set; } = true;
    AudioSource audioSource;
    public GameObject uiElement;
    public ParticleSystem süs;
    public Monitor monitor;
    public AudioMixerGroup steps;
    const string stepsMixerName = "StepsVolume";
    public GameObject monster;


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
        monster.SetActive(false);
        steps.audioMixer.SetFloat(stepsMixerName, -80f);

        while (audioSource.isPlaying)
        {
            monster.SetActive(false);
            yield return null;
        }

        MonsterController.inst.gameObject.SetActive(true);
        steps.audioMixer.ClearFloat(stepsMixerName);
    }
}
