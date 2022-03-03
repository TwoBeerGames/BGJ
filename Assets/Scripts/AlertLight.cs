using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertLight : MonoBehaviour
{
    public float speed = 150f;

    void Start()
    {
        StartCoroutine(alertSignal());
    }

    IEnumerator alertSignal() {
        Vector3 rotationVector = Vector3.zero;
        while (true) {
            rotationVector.y = 2f * speed * Time.deltaTime;
            transform.Rotate(rotationVector);
            yield return null;
        }
    }
}
