using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitch : MonoBehaviour
{ 
    public int selectedItem = 0;

    void Start()
    {
        GlobalInput.masterInput.Mouse.Scroll.performed += ctx => Scrolled(ctx.ReadValue<float>());
        SelectItem();
    }

    void Scrolled (float scroll) {
        Debug.Log(scroll);
        int previousSelectedItem = selectedItem;

        if (scroll > 0f) {
            if (selectedItem >= transform.childCount - 1) {
                selectedItem = 0;
            } else {
                selectedItem++;
            }
        } else if (scroll < 0f) {
            if (selectedItem <= 0) {
                selectedItem = transform.childCount - 1;
            } else {
                selectedItem--;
            }
        }

        if (previousSelectedItem != selectedItem) SelectItem();
    }

    void SelectItem () {
        int counter = 0;
        foreach (Transform item in transform) {
            if (counter == selectedItem) {
                item.gameObject.SetActive(true);
            } else {
                item.gameObject.SetActive(false);
            }
            counter++;
        }
    }
}
