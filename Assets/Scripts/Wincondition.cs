using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Michsky.UI.ModernUIPack;

public class Wincondition : MonoBehaviour, IInteractable
{
    public bool canInteract { get; set; } = true;
    public TMP_Text goodbye;
    public GameObject quitButton;
    public GameObject interactText;
    public Camera playerCamera;
    public Transform cockpit;
    public Light spotLightA;
    public Light spotLightB;
    public AudioSource audioSource;
    public AudioClip headlightIgnite;
    public AudioClip engineStart;
    public AudioClip cargo;
    public AudioSource vacum;
    public Animator gates;
    public ParticleSystem süs;
    public ParticleSystem süs1;
    public ParticleSystem süs2;
    public Animator planeAnimator;
    public Animator cameraanimator;
    // Start is called before the first frame update
    void Start()
    {
        goodbye.alpha = 0f;
        quitButton.SetActive(false);
    }

    public void interact()
    {
        StartCoroutine(theEnd());

    }

    IEnumerator theEnd()
    {
        süs.Stop();
        float timeElapsed = 0f;
        interactText.SetActive(false);
        GlobalInput.masterInput.Disable();
        playerCamera.transform.position = cockpit.position;
        playerCamera.transform.rotation = cockpit.rotation;
        playerCamera.transform.SetParent(cockpit);
        Destroy(cameraanimator);


        bool firstSequence = false;
        bool secondSequence = false;
        bool thirdSequence = false;
        bool fourthSequence = false;
        bool fivthSequence = false;
        bool sixthSequence = false;
        audioSource.PlayOneShot(engineStart);

        while (true)
        {
            timeElapsed += Time.deltaTime;
            //Debug.Log(timeElapsed);
            if (timeElapsed >= .5f && !firstSequence)
            {
                firstSequence = true;
                yield return null;
                continue;

            }
            else if (timeElapsed >= 2f && !secondSequence)
            {
                secondSequence = true;
                audioSource.PlayOneShot(headlightIgnite);
                spotLightA.gameObject.SetActive(true);
                spotLightB.gameObject.SetActive(true);

                audioSource.PlayOneShot(cargo);
                yield return null;
                continue;
            }
            else if (timeElapsed >= 5f && !thirdSequence)
            {
                thirdSequence = true;
                gates.Play("gate_open");
                vacum.Play();
                süs1.Play();
                süs2.Play();
                yield return null;
                continue;
            }
            else if (timeElapsed >= 15f && !sixthSequence)
            {
                sixthSequence = true;
                planeAnimator.Play("plane");
                yield return null;
                continue;
            }
            else if (timeElapsed >= 20f && !fourthSequence)
            {
                fourthSequence = true;
                Fader.inst.goBlack(1f);
                yield return null;
                continue;
            }
            else if (timeElapsed >= 22f && !fivthSequence)
            {
                fivthSequence = true;
                StartCoroutine(fade(0f, 1f, 5f));
                quitButton.SetActive(true);
                yield return null;
                continue;
            }
            yield return null;
        }

    }

    IEnumerator fade(float from, float to, float time)
    {
        float timeElapsed = 0f;
        float progress = 0f;

        while (timeElapsed < time)
        {

            timeElapsed += Time.deltaTime;
            progress = timeElapsed / time;
            goodbye.alpha = Mathf.Lerp(from, to, progress);
            yield return null;
        }

        goodbye.alpha = to;
    }
}
