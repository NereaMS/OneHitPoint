using UnityEngine;

public class StaticAttackState : IEnemyState
{
    private SorcererController _enemy;
    private EnemyStateMachine _stateMachine;
    private float _lastAttackTime;
    private float _cooldownTime;

    public StaticAttackState(SorcererController enemy, EnemyStateMachine stateMachine)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
        _cooldownTime = enemy.fireCoolDown;
    }
    
    public void OnEnter()
    {
        _enemy.StartAnimation("Attack", true);
    }

    public void UpdateState()
    {

        if (_enemy.IsPlayerInAtackRange())
        {
            if (Time.time >= _lastAttackTime + _cooldownTime)
            {
                _enemy.PerformAttack();
                _lastAttackTime = Time.time; //Guardamos el tiempo de la ultima vez que se realizo el ataque
            
            }
        }
    }

    public void OnExit()
    {
        _enemy.StartAnimation("Attack", false);
    }
    
}
