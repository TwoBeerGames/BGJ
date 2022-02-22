using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitch : MonoBehaviour
{ 
    // public int selectedItem = 0;
    // private List<Transform> childs = new List<Transform>();
    // // private Transform[] childs = new Transform[3];

    // void Start()
    // {
    //     GlobalInput.masterInput.Mouse.Scroll.performed += ctx => Scrolled(ctx.ReadValue<float>());
    //     foreach (Transform item in transform) {
    //         childs.Add(item);
    //     }
    //     // int counter = 0;
    //     // foreach (Transform item in transform) {
    //     //     childs[counter] = item;
    //     // }
    //     SelectItem();
    // }

    // void Scrolled (float scroll) {
    //     // int previousSelectedItem = selectedItem;

    //     // if (scroll > 0f) {
    //     //     if (selectedItem >= transform.childCount - 1) {
    //     //         selectedItem = 0;
    //     //     } else {
    //     //         selectedItem++;
    //     //     }
    //     // } else if (scroll < 0f) {
    //     //     if (selectedItem <= 0) {
    //     //         selectedItem = transform.childCount - 1;
    //     //     } else {
    //     //         selectedItem--;
    //     //     }
    //     // }

    //     // if (previousSelectedItem != selectedItem) SelectItem();
    //     Transform previousSelectedItem = childs[selectedItem];

    //     if (scroll > 0f) {
    //         if (selectedItem >= transform.childCount - 1) {
    //             selectedItem = 0;
    //         } else {
    //             selectedItem++;
    //         }
    //     } else if (scroll < 0f) {
    //         if (selectedItem <= 0) {
    //             selectedItem = transform.childCount - 1;
    //         } else {
    //             selectedItem--;
    //         }
    //     }

    //     if (previousSelectedItem != selectedItem) SelectItem();
    // }

    // void SelectItem () {
    //     int counter = 0;
    //     foreach (Transform item in childs) {
    //         if (counter == selectedItem && item.GetComponent<Tool>().unlocked) {
    //             item.gameObject.SetActive(true);
    //         } else {
    //             item.gameObject.SetActive(false);
    //         }
    //         counter++;
    //     }
    // }
    private Transform selectedItem;
    private List<Transform> childs = new List<Transform>();

    void Start()
    {
        GlobalInput.masterInput.Mouse.Scroll.performed += ctx => Scrolled(ctx.ReadValue<float>());
        foreach (Transform item in transform) {
            if (item.GetComponent<Tool>().unlocked) {
                childs.Add(item);
            }
        }
        
        if (childs.Count > 0) {
            selectedItem = childs[0];
        }

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

            if (previousSelectedItem != selectedItem) SelectItem();
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
