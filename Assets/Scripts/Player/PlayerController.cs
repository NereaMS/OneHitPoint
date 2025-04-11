/* Clase encargada de controlar movimiento, ataques y controles del personaje principal.*/


using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
  
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float jumpForce = 20.0f;
    public float gravity = -30;
    public float verticalVelocity = 0f;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
   
    public EnemyController enemy;
   

    private bool isGrounded;
    private Rigidbody2D rb;
    private InputSystem_Actions controls;
    private Vector2 move;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private PlayerMeleeAttack _meleeAttack;
  

    // 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        controls = new InputSystem_Actions();
        _meleeAttack = GetComponent<PlayerMeleeAttack>();

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
        if (move.x < 0)
        {
            spriteRenderer.flipX = true;
            _meleeAttack.FlipAttackPoint(true);
        }
        else if (move.x > 0)
        {
            spriteRenderer.flipX = false;
            _meleeAttack.FlipAttackPoint(false);
            
        }
        
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
        
        float magnitude = move.magnitude;
        animator.SetFloat("Speed", magnitude);
        float currentSpeed =(magnitude > 0.5f ) ? runSpeed : walkSpeed;
        
        rb.linearVelocity = new Vector2(move.x * currentSpeed, verticalVelocity);
        
        
    }

    void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log("Estoy santando!!");
        if (isGrounded)
        {
            
            verticalVelocity = jumpForce;
           
            animator.SetTrigger("Jump");
        }
       
    }

  

   
    void OnDrawGizmos()
    {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * 0.3f);
            
        
    }
    
    //Prueba para recoger pociones
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Potion"))
        {
            Animator anim = collision.GetComponent<Animator>();
           
            if(anim != null)
                anim.SetTrigger("PickedUp");
           
        }
        Destroy(collision.gameObject, 1f);
    }

  
}
