using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitch : MonoBehaviour
{ 
    private Transform selectedItem;
    private List<Transform> childs = new List<Transform>();

    void Start()
    {
        // Event
        GlobalInput.masterInput.Mouse.Scroll.performed += ctx => Scrolled(ctx.ReadValue<float>());

        // Tool Childs
        foreach (Transform item in transform) {
            if (item.GetComponent<Tool>().unlocked) {
                childs.Add(item);
            }
        }
        
        // Set first unlocked Child
        if (childs.Count > 0) {
            selectedItem = childs[0];
        }
        
        // Select first unlocked Child
        SelectItem();
    }

    void Scrolled (float scroll) {
        if (selectedItem) {
            Transform previousSelectedItem = selectedItem;
            int selectedItemIndex = childs.IndexOf(selectedItem);

            if (scroll > 0f) {
                if (selectedItemIndex >= childs.Count - 1) {
                    selectedItem = childs[0];
                } else {
                    selectedItem = childs[selectedItemIndex + 1];
                }
            } else if (scroll < 0f) {
                if (selectedItemIndex <= 0) {
                    selectedItem = childs[childs.Count - 1];
                } else {
                    selectedItem = childs[selectedItemIndex - 1];
                }
            }

            if (previousSelectedItem != selectedItem && !GlobalFunctions.isGamePaused())
                SelectItem();
        }
    }

    void SelectItem () {
        foreach (Transform item in childs) {
            if (item == selectedItem) {
                item.gameObject.SetActive(true);
            } else {
                item.gameObject.SetActive(false);
            }
        }
    }
}
