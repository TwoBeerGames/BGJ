using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFunctions : MonoBehaviour
{
    public static AudioManager audioManager;

    void Awake() {
        audioManager = new AudioManager();
    }

    public static void pauseGame(){
        Time.timeScale = 0;
        audioManager.muteVolume();
    }

    public static void continueGame() {
        Time.timeScale = 1;
        audioManager.unmuteVolume();
    }

    public static bool isGamePaused() {
        if (Time.timeScale == 0) {
            return true;
        } else {
            return false;
        }
    }

    public static void quitGame() {
        Application.Quit();
    }
}
