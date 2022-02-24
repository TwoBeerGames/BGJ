using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : MonoBehaviour
{
    public bool isInRange = false;

    void OnDrawGizmos()
    {
        if (isInRange)
            Gizmos.DrawSphere(transform.position, 1);
    }
}
