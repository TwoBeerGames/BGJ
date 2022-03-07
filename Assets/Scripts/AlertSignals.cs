using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertSignals : MonoBehaviour
{
    public GameObject[] alerts;

    public void Start()
    {
        foreach (GameObject item in alerts)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void startAlert()
    {
        foreach (GameObject item in alerts)
        {
            item.gameObject.SetActive(true);
        }
    }
}
