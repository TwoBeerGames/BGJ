using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTurn : MonoBehaviour
{
    public Vector3 rotationVector = Vector3.zero;
    [Range(0,1000)]
    public int speed = 150;


    void Update() {
        transform.rotation *= Quaternion.Euler(rotationVector * speed * Time.deltaTime);
    }
}
