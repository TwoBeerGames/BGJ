using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;

public class Tutorial : MonoBehaviour
{
    public ModalWindowManager manager;

    void Start()
    {
        gameObject.SetActive(true);
        manager.OpenWindow();
        GlobalFunctions.pauseGame();
    }

    public void handleGotItButton() {
        manager.CloseWindow();
        GlobalFunctions.continueGame();
    }
}
