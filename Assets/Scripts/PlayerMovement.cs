using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float flapStrength = 5f;

    private CustomInput input;
    private Rigidbody2D playerRigidBody;

    private void Awake()
    {
        input = new CustomInput();
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Flap.performed += OnFlapPerformed;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Flap.performed -= OnFlapPerformed;
    }

    private void OnFlapPerformed(InputAction.CallbackContext value)
    {
        playerRigidBody.velocity = Vector2.up * flapStrength;
    }
}
