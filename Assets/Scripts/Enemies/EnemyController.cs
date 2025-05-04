
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyStateMachine StateMachine { get; set; }
    public float slowSpeed =0.1f;
    public float fastSpeed = 3f;
    public int health=2;

   
    public float patrolDistance = 5f;
    public float attackRange = 5f;
    public float visionRange = 10f;
    public Transform player;
    
    private Vector2 move;
    private Rigidbody2D _rb;
    private Animator _animator;
    private bool _isDead= false;
    private float _distance;
    private SpriteRenderer spriteRenderer;
    public bool IsDead => _isDead;
    private IAttackHandler _attackHandler;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator= GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _attackHandler = GetComponent<IAttackHandler>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        StateMachine = new EnemyStateMachine();
        StateMachine.Initialize(this);
        StateMachine.SetState(new PatrolState(this, StateMachine));
    }

    // Update is called once per frame
    void Update()
    {
        //
        //{
           StateMachine.UpdateState();
        //}
    }


    public void MoveTowardsPlayer(float speed)
    {
        Vector2 direction = (player.position - transform.position).normalized;
        _rb.linearVelocity = new Vector2(direction.x * speed, 0);
        
        if(direction.x >0)
            spriteRenderer.flipX = true;
        if(direction.x <  0)
            spriteRenderer.flipX = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{name} ha recibido {damage} daño. Vida restante: {health}");
        Debug.Log(_isDead);
        if (health <= 0 && !_isDead)
        {
            Debug.Log($"{name} ha muerto");
            _isDead = true;
        }
    }

    public void StartAnimation(string animationName, bool value)
    {
        _animator.SetBool(animationName, value);
    }

    public void StopMovement()
    {
        _rb.linearVelocity = Vector2.zero;
    }
    
    public bool IsPlayerInRange()
    {
        _distance = Vector2.Distance(transform.position, player.position);
        _distance = Mathf.Round(_distance * 100f) / 100f;
       // Debug.Log(_distance);
        return _distance <= visionRange;
    }

    public bool IsPlayerInAtackRange()
    {
        _distance = Vector2.Distance(transform.position, player.position);
        _distance = Mathf.Abs(_distance * 100f) /100f;
       
        return _distance <= attackRange +0.1f;
    }

    public void MoveRandomly(float speed)
    {
        Vector2 direction = patrolDistance > 0 ? Vector2.right : Vector2.left;
                           
        _rb.linearVelocity= direction * speed;
        spriteRenderer.flipX = direction.x > 0;
        patrolDistance-= speed * Time.deltaTime;

        if (Mathf.Abs(patrolDistance) <= 0.1f)
        {
            patrolDistance = - patrolDistance;
        }
    }

    public void PerformAttack()
    {
        if(_attackHandler != null)
            _attackHandler.PerformAttack();
    }
    
}

