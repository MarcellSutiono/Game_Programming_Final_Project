using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer sr;
    private PlayerData pd;
    private Rigidbody2D rb;
    private PlayerInput input;
    private Animator anim;
    private GameSound gs;

    //Ground Check
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;

    //Power up
    [SerializeField] private GameObject sun;
    private LineRenderer aim;
    private bool isAiming = false;

    private void Awake()
    {
        Time.timeScale = 1f;
        input = new PlayerInput();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Movement.Jump.performed += Jump_performed;
        input.Movement.Jump.canceled += Jump_canceled;
        input.Movement.Attack.performed += Attack_performed;
        input.Movement.Aim.performed += Aim_performed;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Aim_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(pd.IsSun)
        {
            isAiming = !isAiming;
            if(!isAiming)
            {
                aim.SetPosition(0, gameObject.transform.position);
                aim.SetPosition(1, gameObject.transform.position);
            }
        }
    }

    private void Attack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(!isAiming)
        {
            gs.PlaySFX(gs.throwCap);
            anim.SetTrigger("Attack");
        }
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(!pd.IsJump && inGround())
        {
            gs.PlaySFX(gs.jump);
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
        sr = GetComponent<SpriteRenderer>();
        aim = GetComponent<LineRenderer>();
        gs = FindObjectOfType<GameSound>();
    }

    private void Update()
    {
        move();
        aimShoot();
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
        if (moveVal < 0)
        {
            sr.flipY = true;
        }
        else if(moveVal > 0)
        {
            sr.flipY = false;
        }
    }

    private bool inGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);
    }

    private void aimShoot()
    {
        if(isAiming)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Vector2 dir = (mousePos - transform.position).normalized;

            Vector3 playerPos = gameObject.transform.position;
            playerPos.y += 2.85f;

            aim.SetPosition(0, playerPos);
            aim.SetPosition(1, playerPos + (Vector3)(dir * 100f));

            RaycastHit2D hit = Physics2D.Raycast(playerPos, dir, 1000f);
            Debug.DrawRay(playerPos, dir * 100f, Color.red, 1f);

            if(hit.collider != null)
            {
                if(hit.collider.CompareTag("Bunny"))
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        gs.PlaySFX(gs.beam);
                        hit.collider.gameObject.GetComponent<MrBunny>().sunDamage();
                    }
                }
            }

        }
    }
}
