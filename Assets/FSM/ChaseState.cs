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
