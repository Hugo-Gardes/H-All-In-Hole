using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Vector3 direction;
    public InputActionReference moveAction;
    public float speed = 5f;

    private void OnEnable()
    {
        moveAction.action.performed += OnMovePerformed;
        moveAction.action.canceled += OnMoveCanceled;
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.performed -= OnMovePerformed;
        moveAction.action.canceled -= OnMoveCanceled;
        moveAction.action.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        direction = Vector3.zero;
    }

    void Update()
    {
        Vector3 move = new(direction.x, 0f, direction.y);

        if (move.sqrMagnitude > 1f)
        {
            move.Normalize();
        }

        transform.Translate(speed * Time.deltaTime * move, Space.World);
    }
}
