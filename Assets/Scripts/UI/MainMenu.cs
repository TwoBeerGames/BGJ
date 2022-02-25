using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool sceenLoaded = false;

    public void PlayGame() {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        if (sceenLoaded == false && sceneCount > 1 ) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            sceenLoaded = true;
        }
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}