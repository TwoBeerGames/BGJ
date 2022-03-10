using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDoor : MonoBehaviour, IInteractable
{
    public bool canInteract { get; set; } = true;
    public Vector3 destinationRotation = Vector3.zero;
    public ParticleSystem süs;
    public float duration = 1f;
    Quaternion initialRotation;
    // Start is called before the first frame update

    void Start()
    {
        initialRotation = transform.rotation;
    }
    IEnumerator squeek()
    {
        float timeElapsed = 0f;
        float progress = 0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            progress = timeElapsed / duration;
            transform.rotation = initialRotation * Quaternion.Euler(destinationRotation * progress);
            yield return null;
        }

        transform.rotation = initialRotation * Quaternion.Euler(destinationRotation);

    }

    public void interact()
    {
        if (canInteract)
        {
            MonsterDelay.inst.respawn();
            GetComponent<AudioSource>().Play();
            canInteract = false;
            süs.Stop();
            StartCoroutine(squeek());
        }
    }
}
