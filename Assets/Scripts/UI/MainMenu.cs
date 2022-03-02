using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool sceenLoaded = false;

    public void playGame() {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        if (sceenLoaded == false && sceneCount > 1 ) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            sceenLoaded = true;
        }
    }

    public void quitGame() {
        GlobalFunctions.quitGame();
    }
}
