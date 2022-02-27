using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    public Transform cam;
    public TMP_Text interactUI;
    public RawImage wad;
    Color initColor;
    public float interactRange = 1f;
    public LayerMask whatIsInteractable;
    void Start()
    {
        GlobalInput.masterInput.Interaction.Interact.performed += ctx => tryInteract();
        initColor = wad.color;
    }


    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, interactRange, whatIsInteractable))
        {
            if (hit.transform.GetComponent<IInteractable>().canInteract)
            {
                wad.color = initColor;
                interactUI.alpha = .25f;
            }

        }
        else
        {
            wad.color = new Color(0f, 0f, 0f, 0f);
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
