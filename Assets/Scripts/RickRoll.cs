using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RickRoll : MonoBehaviour, IInteractable
{
    public bool canInteract { get; set; }
    public GameObject rick;
    void Start()
    {
        canInteract = true;
    }

    // Update is called once per frame
    public void interact()
    {
        if (canInteract)
        {   
            canInteract = false;
            GetComponent<AudioSource>().Play();
            rick.SetActive(true);
        }

    }
}
