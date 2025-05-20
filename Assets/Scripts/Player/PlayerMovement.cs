using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    private PlayerData pd;
    private Rigidbody2D rb;
    private PlayerInput input;
    private Animator anim;

    private bool right = true;
    private bool attack = false;

    //Ground Check
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;

    private void Awake()
    {
        input = new PlayerInput();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Movement.Jump.performed += Jump_performed;
        input.Movement.Jump.canceled += Jump_canceled;
        input.Movement.Attack.performed += Attack_performed;
    }

    private void Attack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        anim.SetTrigger("Attack");
        attack = true;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(!pd.IsJump && inGround())
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
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        move();
    }

    private void move()
    {
        float horizontal = input.Movement.Move.ReadValue<float>();
        flip(horizontal);
        rb.velocity = new Vector2(horizontal * pd.PlayerSpd, rb.velocity.y);

        if (horizontal != 0)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }

    private void flip(float moveVal)
    {
        if (moveVal < 0 && right || moveVal > 0 && !right)
        {
            right = !right;
            Vector3 scale = transform.localScale;
            scale.y *= -1;
            transform.localScale = scale;
        }
    }

    private bool inGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);
    }
}
