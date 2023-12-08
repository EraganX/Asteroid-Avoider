using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float rotationSpeed;

    private Rigidbody rb;
    private Camera cam;

    private Vector3 _moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void Update()
    {
        UserInputs();
        KeepPlayerOnScreen();
        RotateToFaceVelocity();

    }

    private void RotateToFaceVelocity()
    {
        if(rb.velocity == Vector3.zero) { return; }

        Quaternion targetRotaion = Quaternion.LookRotation(rb.velocity, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation,targetRotaion,rotationSpeed*Time.deltaTime);

    }

    private void UserInputs()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = cam.ScreenToWorldPoint(touchPosition);
            _moveDirection = transform.position - worldPosition;
            _moveDirection.y = 0f;
            _moveDirection.Normalize();
        }
        else
        {
            _moveDirection = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        if (_moveDirection == Vector3.zero) { return; }

        rb.AddForce(_moveDirection * forceMagnitude * Time.fixedDeltaTime, ForceMode.Force);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }

    private void KeepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewportPosition = cam.WorldToViewportPoint(transform.position);
        if (viewportPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
        }
        else if (viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }

        if (viewportPosition.y > 1)
        {
            newPosition.z = -newPosition.z + 0.1f;
        }
        else if (viewportPosition.y < 0)
        {
            newPosition.z = -newPosition.z - 0.1f;
        }

        transform.position = newPosition;
    }
}
