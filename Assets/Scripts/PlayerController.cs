using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController cc;
    Vector3 movementVector = Vector3.zero;
    public float movementSpeed;
    Vector3 initialRotation;
    Vector3 rotationOffset = Vector3.zero;
    Vector3 initialCameraAnchorRotation = Vector3.zero;
    Vector2 mouseDelta = Vector2.zero;

    public float mouseSensivity = 1f;

    public Transform cameraAnchor;


    // Start is called before the first frame update
    void Start()
    {
        GlobalInput.masterInput.Mouse.MouseDelta.performed += ctx => { mouseDelta = ctx.ReadValue<Vector2>(); };

        initialRotation = transform.rotation.eulerAngles;
        initialCameraAnchorRotation = cameraAnchor.localRotation.eulerAngles;

        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        createMovementVector();
        setRotation();

        cc.Move(movementVector * movementSpeed * Time.deltaTime + -Vector3.up);

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
    }
}
