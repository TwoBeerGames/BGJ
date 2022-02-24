using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Transform head;
    public Transform player;
    // Start is called before the first frame update

    // Update is called once per frame
    void LateUpdate()
    {
        // head.position = transform.position;
        // head.rotation = transform.rotation;
        //head.LookAt(player);
        head.rotation = transform.rotation;
        head.rotation *= Quaternion.AngleAxis(180f, head.forward);
        head.rotation *= Quaternion.AngleAxis(90f, head.right);
        //head.right += Quaternion.Euler(0,0,180f) * transform.forward;

    }
}
