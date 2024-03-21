using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerInputActions inputActions;
    public float forceMovement = 1;
    public bool alive = true;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Enable();
    }

    void Start()
    {
        inputActions.Standard.Movement.performed += Move;
    }

    private void Move(InputAction.CallbackContext context)
    {
        Vector2 movementInput = context.ReadValue<Vector2>();
        Vector3 direction = new Vector3(movementInput.x, 0, movementInput.y) * forceMovement;
        transform.position += direction;
    }


}
