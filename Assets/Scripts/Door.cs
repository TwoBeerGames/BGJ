using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public bool canInteract { get; set; } = true;
    public Transform opened;
    public Transform actualDoor;
    Vector3 closed;
    public bool open;
    AudioSource audioSource;
    public float switchTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        closed = actualDoor.position;
    }

    IEnumerator switchState()
    {
        float switchTimeLeft = switchTime;
        canInteract = false;

        
        audioSource.Play();

        while (switchTimeLeft > 0)
        {
            switchTimeLeft -= Time.deltaTime;
            float progress = switchTimeLeft / switchTime;

            if (open)
                actualDoor.position = Vector3.Lerp(closed, opened.position, progress);
            else
                actualDoor.position = Vector3.Lerp(opened.position, closed, progress);

            yield return null;
        }


        if (open)
            actualDoor.position = closed;
        else
            actualDoor.position = opened.position;

        open = !open;
        canInteract = true;
    }

    public void interact()
    {
        if (canInteract)
        {
            StartCoroutine(switchState());
        }
    }
}
