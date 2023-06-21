using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float flapStrength = 5f;

    private CustomInput input;
    private Rigidbody2D playerRigidBody;
    private GameManager gameManager;

    private void Awake()
    {
        input = new CustomInput();
        playerRigidBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            gameManager.GameOver();
            input.Disable();
        }
    }
}
