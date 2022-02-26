using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public Transform cam;
    public TMP_Text interactUI;
    public float interactRange = 1f;
    public LayerMask whatIsInteractable;
    void Start()
    {
        GlobalInput.masterInput.Interaction.Interact.performed += ctx => tryInteract();
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, interactRange, whatIsInteractable))
        {
            interactUI.alpha = .25f;
        }
        else
        {
            interactUI.alpha = 0;
        }
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
            }
        }
    }
}
