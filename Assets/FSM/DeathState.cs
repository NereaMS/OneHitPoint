using UnityEngine;

public class DeathState : IEnemyState
{
    private EnemyController _enemy;
    
    private EnemyStateMachine _stateMachine;

    public DeathState(EnemyController enemy, EnemyStateMachine stateMachine)
    {
        this._enemy = enemy;
        this._stateMachine = stateMachine;
    }

    public void OnEnter()
    {
        Debug.Log("Entered Death State");
        _enemy.StopMovement();
        _enemy.StartAnimation("Death", true);
        Object.Destroy(_enemy.gameObject, 1.3f);
    }

    public void UpdateState()
    {
        
    }

    public void OnExit()
    {
        
    }
}
