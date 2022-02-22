using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public bool canInteract { get; set; }
    public Transform opened;
    Vector3 closed;
    public bool open;
    public float switchTime;

    void Start()
    {
        closed = transform.position;
        canInteract = true;
    }

    IEnumerator switchState()
    {
        float switchTimeLeft = switchTime;
        canInteract = false;

        while (switchTimeLeft > 0)
        {
            switchTimeLeft -= Time.deltaTime;
            float progress = switchTimeLeft / switchTime;

            if (open)
                transform.position = Vector3.Lerp(closed, opened.position, progress);
            else
                transform.position = Vector3.Lerp(opened.position, closed, progress);

            yield return null;
        }

        if (open)
            transform.position = closed;
        else
            transform.position = opened.position;

        open = !open;
        canInteract = true;
    }

    public void interact()
    {
        if (canInteract)
        {
            Debug.Log("yes");
            StartCoroutine(switchState());
        }
    }
}
