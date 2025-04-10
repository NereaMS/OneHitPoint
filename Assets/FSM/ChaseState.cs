using System.Runtime.CompilerServices;
using UnityEngine;

public class ChaseState : IEnemyState
{
    private EnemyController _enemy;
    private EnemyStateMachine _stateMachine;

    public ChaseState(EnemyController enemy, EnemyStateMachine stateMachine)
    {
        this._enemy = enemy;
        this._stateMachine = stateMachine;
    }
    
    public void OnEnter()
    {
        Debug.Log("Entered ChaseState");
        _enemy.StartAnimation("WalkFast", true);
    }
    public void UpdateState()
    {
       
        
        if (_enemy.IsPlayerInAtackRange())
        {
          
            _enemy.StopMovement();
            _stateMachine.SetState(new AttackState(_enemy, _stateMachine));
            return;
        }
        //bool respuesta= _enemy.IsPlayerInAtackRange();
        //Debug.Log(respuesta);

        if (!_enemy.IsPlayerInRange())
        {
            Debug.Log("No hay jugador cerca, cambiando de estado");
            _stateMachine.SetState(new PatrolState(_enemy, _stateMachine));
            return;
        }
        _enemy.MoveTowardsPlayer(_enemy.fastSpeed);
    }
    public void OnExit()
    {
        Debug.Log("Exited ChaseState");
    }
}
