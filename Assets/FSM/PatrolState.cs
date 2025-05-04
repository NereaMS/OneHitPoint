using UnityEngine;

public class PatrolState : IEnemyState
{

    private EnemyController _enemy;
    private EnemyStateMachine _stateMachine;

    public PatrolState(EnemyController enemy, EnemyStateMachine stateMachine)
    {
        this._enemy = enemy;
        this._stateMachine = stateMachine;
    }

    public void OnEnter()
    {
       
        //animacion de caminar
      
        _enemy.StartAnimation("WalkFast", false);
    }

    public void UpdateState()
    {
        //Si el personaje esta a rango pasamos al estado de perseguir (CHase)

        if (_enemy.IsPlayerInRange())
        {
            _stateMachine.SetState(new ChaseState(_enemy, _stateMachine));
            return;
        }
        
        _enemy.MoveRandomly(_enemy.slowSpeed);
    }

    public void OnExit()
    {
        Debug.Log("Exited PatrolState");
    }
}
