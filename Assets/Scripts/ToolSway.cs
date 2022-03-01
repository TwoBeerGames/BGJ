using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSway : MonoBehaviour
{
    public Vector3 offset = Vector3.zero;
    public float limit = 1f;
    public float intensity = 1f;
    public float resetSpeed = 1f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        offset += new Vector3(GlobalInput.mouseDelta.y * -intensity * Time.deltaTime, GlobalInput.mouseDelta.x * intensity * Time.deltaTime, 0f);
        offset = new Vector3(Mathf.Clamp(offset.x, -limit, limit), Mathf.Clamp(offset.y, -limit, limit), 0);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(offset), 10);
        offset += -offset * Time.deltaTime * resetSpeed;
    }
}
