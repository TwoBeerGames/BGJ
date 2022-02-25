using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POIVisualizer : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        foreach (Transform child in transform)
        {
            Gizmos.DrawCube(child.position, Vector3.one);
        }
    }
}
