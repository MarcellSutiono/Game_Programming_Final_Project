using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    private PlayerData pd;
    private Rigidbody2D rb;
    private PlayerInput input;

    private void Awake()
    {
        input = new PlayerInput();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Movement.Jump.performed += Jump_performed;
        input.Movement.Jump.canceled += Jump_canceled;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(!pd.IsJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, pd.JumpPower);
            pd.IsJump = true;
        }
    }

    private void Jump_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        pd.IsJump = false;
    }

    private void Start()
    {
        pd = PlayerData.getInstance();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = input.Movement.Move.ReadValue<float>();
        rb.velocity = new Vector2(horizontal * pd.PlayerSpd, rb.velocity.y);
    }
}
