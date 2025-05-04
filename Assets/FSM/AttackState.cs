using UnityEngine;

public class AttackState : IEnemyState
{
    private EnemyController _enemy;
    private EnemyStateMachine _stateMachine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AttackState(EnemyController enemy, EnemyStateMachine stateMachine)
    {
        this._enemy = enemy;
        this._stateMachine = stateMachine;
    }

    public void OnEnter()
    {
       
        _enemy.StopMovement();
        _enemy.PerformAttack();
        
        _enemy.StartAnimation("Attack", true);
    }

    public void UpdateState()
    {
        if (!_enemy.IsPlayerInAtackRange())
        {
            _stateMachine.SetState(new ChaseState(_enemy, _stateMachine));
            return;
        }
        
    }

    public void OnExit()
    {
        Debug.Log("Exit de ataque");
        
    }
}
