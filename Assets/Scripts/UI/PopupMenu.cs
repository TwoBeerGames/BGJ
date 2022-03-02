using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Michsky.UI.ModernUIPack;

public class PopupMenu : MonoBehaviour
{
    public ModalWindowManager popupMenu;
    private bool popupMenuOpen = false;

    void Start() {
        GlobalInput.masterInput.Menu.Escape.performed += ctx => toggleVisibility();
    }

    public void toggleVisibility() {
        if (!popupMenuOpen) {
            popupMenu.OpenWindow();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            popupMenuOpen = true;
            GlobalFunctions.pauseGame();
        } else {
            popupMenu.CloseWindow();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            popupMenuOpen = false;
            GlobalFunctions.continueGame();
        }
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }

}
