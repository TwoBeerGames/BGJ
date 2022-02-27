using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryProgression : MonoBehaviour
{
    public static UnityEvent progressionUpdate = new UnityEvent();
    public int audioLogsFound = 0;
    public GameObject evilman;

    public GameObject hangarGate;
    public Door hangarDoor;
    public AudioLog sarah;
    public AudioLog i_evilman;
    void Start()
    {
        progressionUpdate.AddListener(progressStory);
        evilman.SetActive(false);
        hangarDoor.canInteract = false;
    }

    void progressStory()
    {
        audioLogsFound++;
        if (audioLogsFound == 1)
        {
            evilman.SetActive(true);
        }
        else if (audioLogsFound == 2)
        {
            hangarDoor.canInteract = true;
            hangarGate.SetActive(false);
        }
    }
}
