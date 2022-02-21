using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInput : MonoBehaviour
{
    public static MasterInput masterInput;

    public static bool forwardDown = false;
    public static bool backwardDown = false;
    public static bool leftDown = false;
    public static bool rightDown = false;



    void Awake()
    {
        StartCoroutine(init());
        masterInput = new MasterInput();
    }

    IEnumerator init()
    {
        yield return new WaitForSeconds(1f);

        
        masterInput.Enable();

        //Forward
        masterInput.Movement.ForwardDown.performed += ctx => { forwardDown = true; };
        masterInput.Movement.ForwardUp.performed += ctx => { forwardDown = false; };

        //Baclward
        masterInput.Movement.BackwardDown.performed += ctx => { backwardDown = true; };
        masterInput.Movement.BackwardUp.performed += ctx => { backwardDown = false; };

        //Left
        masterInput.Movement.LeftDown.performed += ctx => { leftDown = true; };
        masterInput.Movement.LeftUp.performed += ctx => { leftDown = false; };

        //Right
        masterInput.Movement.RightDown.performed += ctx => { rightDown = true; };
        masterInput.Movement.RightUp.performed += ctx => { rightDown = false; };
    }
}
