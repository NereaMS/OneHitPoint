/* Clase encargada de controlar movimiento, ataques y controles del personaje principal.*/


using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public float gravity = -30;
    public float verticalVelocity = 0f;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
   

    private bool isGrounded;
    private Rigidbody2D rb;
    private GameController controls;
    private Vector2 move;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isJumpPressed = false;

    // 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        controls = new GameController();
        controls.Player.Attack.performed += ctx => OnAttack();
    }

    void OnEnable()
    {
        controls.Enable();
        controls.Player.Jump.performed += OnJump;

    }

    void OnDisable()
    {
       
        controls.Player.Jump.performed -= OnJump;
        controls.Disable();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = controls.Player.Move.ReadValue<Vector2>();
        animator.SetFloat("Speed", Mathf.Abs(move.x));
       
        
        //Flip image
        if(move.x < 0)
            spriteRenderer.flipX = true;
        if(move.x > 0)
            spriteRenderer.flipX = false;
        Debug.DrawRay(transform.position, Vector3.down *1f, Color.green);
       


    }

    void FixedUpdate()
    {
      
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.3f, groundMask);
        
        isGrounded = hit.collider is not null;

        //isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundDistance, groundMask);
        animator.SetBool("isGrounded", isGrounded);
        //rb.linearVelocity = new Vector2(move.x * moveSpeed, rb.linearVelocity.y);

        if (!isGrounded)
        {
            verticalVelocity += gravity * Time.fixedDeltaTime;
        }
        else if (verticalVelocity < 0)
        {
            verticalVelocity = 0f;
        }
        
        rb.linearVelocity = new Vector2(move.x * moveSpeed, rb.linearVelocity.y);
        
        
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            verticalVelocity = jumpForce;
            animator.SetTrigger("Jump");
        }
       
    }

    void OnAttack()
    {
        animator.SetTrigger("Attack");
    }

   
    void OnDrawGizmos()
    {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * 0.3f);
            
        
    }
}
