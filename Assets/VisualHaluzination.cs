using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualHaluzination : MonoBehaviour
{
    public Transform player;
    public GameObject mesh;
    public float fadeDistanceThreshhold = 1f;
    
    void Start(){
        player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        float distance = Vector3.Distance(Vector3.Scale(transform.position, new Vector3(1, 0, 1)), Vector3.Scale(player.position, new Vector3(1, 0, 1)));
        //distance += offset;
        if (distance >= fadeDistanceThreshhold && !Flashlight.on)
        {

            mesh.SetActive(true);
        }
        else
        {
            mesh.SetActive(false);
        }

    }

    void LateUpdate()
    {
        transform.LookAt(player.position);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
