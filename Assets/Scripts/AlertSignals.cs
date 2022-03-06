using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertSignals : MonoBehaviour
{
    public GameObject[] alerts;
    
    public void startAlert() {
        foreach (GameObject item in alerts)
        {
            item.gameObject.SetActive(true);
        }
    }
}
