using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Michsky.UI.ModernUIPack;

public class PopupMenu : MonoBehaviour
{
    public ModalWindowManager popupMenu;
    private bool popupMenuOpen = false;
    private bool sceenLoaded = false;

    void Start() {
        GlobalInput.masterInput.Menu.Escape.performed += ctx => toggleVisibility();
    }

    public void toggleVisibility() {
        if (!popupMenuOpen) {
            popupMenu.OpenWindow();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            popupMenuOpen = true;
        } else {
            popupMenu.CloseWindow();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            popupMenuOpen = false;
        }
    }

    public void goBackToMainMenu() {
        SceneManager.LoadScene(0);
    }
}
