using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header("Weight")]

    public static UnityEvent die = new UnityEvent();
    public float acceleration;
    public float deceleration;
    Vector3 _velocity = Vector3.zero;
    public Animator headAnimator;
    CharacterController cc;
    Vector3 movementVector = Vector3.zero;
    public float maxSpeed;
    Vector3 initialRotation;
    Vector3 rotationOffset = Vector3.zero;
    Vector3 initialCameraAnchorRotation = Vector3.zero;
    Vector2 mouseDelta = Vector2.zero;

    public float mouseSensivity = 1f;
    static bool dead = false;
    public static PlayerController inst;

    public Transform cameraAnchor;
    [Header("Headbob")]
    public AnimancerComponent animancer;
    public AnimationClip bob;
    public AnimationClip nothing;
    public AudioClip deathScream;
    public AudioSource audioSource;
    Vector3 initialPosition;


    // Start is called before the first frame update
    void Start()
    {
        die.AddListener(Die);
        GlobalInput.masterInput.Mouse.MouseDelta.performed += ctx => { mouseDelta = ctx.ReadValue<Vector2>(); };

        initialRotation = transform.rotation.eulerAngles;
        initialPosition = transform.position;
        initialCameraAnchorRotation = cameraAnchor.localRotation.eulerAngles;

        cc = GetComponent<CharacterController>();
        inst = this;

    }

    // Update is called once per frame
    void Update()
    {

        createMovementVector();
        calculateVelocity();
        setRotation();



        cc.Move(_velocity * Time.deltaTime + -Vector3.up);

    }

    void OnEnable()
    {
        Fader.inst.clear();
    }
    private void calculateVelocity()
    {
        if (movementVector != Vector3.zero)
        {
            _velocity += movementVector * Time.deltaTime * acceleration;
            _velocity = Vector3.ClampMagnitude(_velocity, maxSpeed);
        }
        else
        {
            if (_velocity.magnitude > 0.01f)
            {
                _velocity *= Time.deltaTime * deceleration;
            }
            else
            {
                _velocity = Vector3.zero;
            }
        }
    }



    void setRotation()
    {
        rotationOffset.y += mouseDelta.x * mouseSensivity * Time.deltaTime;
        rotationOffset.x += mouseDelta.y * mouseSensivity * -Time.deltaTime;

        rotationOffset.x = Mathf.Clamp(rotationOffset.x, -90, 90);

        transform.rotation = Quaternion.Euler(initialRotation) * Quaternion.Euler(0f, rotationOffset.y, 0f);
        cameraAnchor.localRotation = Quaternion.Euler(initialCameraAnchorRotation) * Quaternion.Euler(rotationOffset.x, 0f, 0f);
    }

    void createMovementVector()
    {
        movementVector = Vector3.zero;

        if (GlobalInput.forwardDown)
            movementVector += transform.forward;

        if (GlobalInput.backwardDown)
            movementVector += -transform.forward;

        if (GlobalInput.leftDown)
            movementVector += -transform.right;

        if (GlobalInput.rightDown)
            movementVector += transform.right;

        if (movementVector == Vector3.zero)
        {
            animancer.Play(nothing, 0.25f);
        }
        else
        {
            var state = animancer.Play(bob, 0.25f);
            state.Speed = .25f;
        }


    }

    public void scream()
    {
        audioSource.PlayOneShot(deathScream);
    }
    public void Die()
    {
        if (!dead)
        {
            dead = true;
            respawn();
        }
    }

    public void respawn()
    {
        StoryProgression.inst.reset();
        dead = false;
        gameObject.SetActive(false);
        transform.position = initialPosition;
        transform.rotation = Quaternion.Euler(initialRotation);
        gameObject.SetActive(true);
    }
}
