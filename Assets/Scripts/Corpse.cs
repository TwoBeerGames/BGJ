using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour
{
    public GameObject[] corpses;
    // Start is called before the first frame update
    void Start()
    {
        corpses[Random.Range(0, corpses.Length)].SetActive(true);
        transform.rotation = Quaternion.Euler(Random.Range(-360f, 360f), Random.Range(-360f, 360f), Random.Range(-360f, 360f));
        StartCoroutine(setStatic());
    }

    IEnumerator setStatic()
    {
        yield return new WaitForSeconds(3f);
        Rigidbody[] rigidbodies;
        rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rigidbodies)
        {
            Transform currentTransform = rb.transform;
            Destroy(currentTransform.GetComponent<Collider>());
            rb.isKinematic = true;
            rb.gameObject.isStatic = true;
        }
        yield return null;
    }
}
