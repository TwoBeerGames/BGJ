using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;

public class Tutorial : MonoBehaviour
{
    public ModalWindowManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager.OpenWindow();
        setGamePaused(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGamePaused(bool paused){
        if(paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
