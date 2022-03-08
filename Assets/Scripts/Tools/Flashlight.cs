using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Tool
{
    [Header("References")]
    public Light lightSource;
    public AudioSource audioSource;
    public GameObject hand;
    public static bool on = false;
    public Transform alien;
    public LayerMask whatIsRaycastable;
    public float triggerAngle = 5f;
    MonsterController monc;

    void Start()
    {
        lightSource.gameObject.SetActive(false);
        monc = alien.GetComponent<MonsterController>();
    }

    void FixedUpdate()
    {
        if (alien.gameObject.activeInHierarchy && on)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, alien.transform.position - transform.position, out hit, 100f, whatIsRaycastable))
            {
                MonsterController mc = hit.transform.GetComponent<MonsterController>();
                if (mc != null)
                {
                    if (Vector3.Angle(transform.right, alien.transform.position - transform.position) <= triggerAngle)
                    {
                        mc.aggroPlayer();
                        mc.buff(true);
                    }
                }
            }
        }
    }

    void OnEnable()
    {
        GlobalInput.masterInput.Mouse.LeftClick.performed += switchLight;
        hand.SetActive(true);
    }

    void OnDisable()
    {
        GlobalInput.masterInput.Mouse.LeftClick.performed -= switchLight;
        hand.SetActive(false);
    }

    void switchLight(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!GlobalFunctions.isGamePaused())
        {
            on = !on;
            audioSource.Play();
            lightSource.gameObject.SetActive(on);
        }
    }
}
