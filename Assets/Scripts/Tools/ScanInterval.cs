using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ScanInterval : MonoBehaviour
{
    public static UnityEvent ping = new UnityEvent();
  
    public Camera cam;
    public float interval = 1f;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(beginPulse());
    }

    IEnumerator beginPulse()
    {
        float timeElapsed = 0;

        while (true)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= interval)
            {
                ping.Invoke();
                cam.gameObject.SetActive(true);
                yield return new WaitForFixedUpdate();
                cam.gameObject.SetActive(false);
                timeElapsed = 0f;
            }

            yield return null;
        }
    }
}
