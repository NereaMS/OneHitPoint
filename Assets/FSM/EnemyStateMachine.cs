using UnityEngine;

public class EnemyStateMachine
{
   private EnemyController _enemy;
   private IEnemyState  _currentState;


   public void Initialize(EnemyController enemy)
   {
      _enemy = enemy;
   }
   public void SetState(IEnemyState newState)
   {
      if(_currentState != null)
         _currentState.OnExit();
     
      _currentState = newState;
      _currentState.OnEnter();
   }

   public void UpdateState()
   {
      if(_currentState == null)
         Debug.LogError("No hay estado actual");

      if (_enemy.health <= 0 && _enemy.IsDead)
      {
         Debug.Log("No estaba muerto, estaba de parrandaaaa");
         SetState(new DeathState(_enemy, this));
      }
      _currentState?.UpdateState();
   }
}
