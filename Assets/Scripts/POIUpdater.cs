using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POIUpdater : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "POI")
            other.gameObject.GetComponent<PointOfInterest>().isInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "POI")
             other.gameObject.GetComponent<PointOfInterest>().isInRange = false;
    }
}
