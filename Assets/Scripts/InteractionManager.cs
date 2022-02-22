using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public Transform cam;
    public float interactRange = 1f;
    public LayerMask whatIsInteractable;
    void Start()
    {
        GlobalInput.masterInput.Interaction.Interact.performed += ctx => tryInteract();
    }

    // Update is called once per frame
    void tryInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, interactRange, whatIsInteractable))
        {
            IInteractable inter = hit.transform.GetComponent<IInteractable>();
            if (inter != null)
            {
                inter.interact();
                Debug.Log("yes interaction, indeed");
            }
        }
    }
}
