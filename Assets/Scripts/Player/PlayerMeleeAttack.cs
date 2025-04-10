using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMeleeAttack : MonoBehaviour
{
    
  

    public Transform attackPoint;
    public int attackDamage = 1;
    public float attackRadius = 0.5f;
   

    public LayerMask enemy;

    
    private Animator _animator;
    private InputSystem_Actions _controls;
    private bool _isAttacking;


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _controls = new InputSystem_Actions();
    }

    void OnEnable()
    {
        _controls.Enable();
        _controls.Player.Attack.performed += OnAttack;
    }

    void OnDisable()
    {
        _controls.Player.Attack.performed -= OnAttack;
        _controls.Disable();
        
    }

    public void FlipAttackPoint(bool isFlipped)
    {
        if (isFlipped)
        {
            attackPoint.localPosition = new Vector3(-Mathf.Abs(attackPoint.localPosition.x), attackPoint.localPosition.y, attackPoint.localPosition.z);
                
        }
        else
        {
            attackPoint.localPosition = new Vector3(Mathf.Abs(attackPoint.localPosition.x), attackPoint.localPosition.y, attackPoint.localPosition.z);

        }
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
       
        _animator.SetBool("isAttacking" ,true);
       
    }

    public void PerformAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemy);
        Debug.Log(hitEnemies.Length);

        
       
        foreach (Collider2D enemyGameObject in hitEnemies)
        {
            EnemyController enemyController = enemyGameObject.GetComponent<EnemyController>();
            if (enemyController != null) //&& !damagedEnemies.Contains(enemyController))
            {
               
                enemyController.TakeDamage(attackDamage);
                
            }
        }
    }

    private void EndAttack()
    {
        //Debug.Log("SE acabo el atacar");
        _animator.SetBool("isAttacking", false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
