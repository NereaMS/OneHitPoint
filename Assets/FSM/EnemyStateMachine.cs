using UnityEngine;

public class EnemyStateMachine 
{
   private IEnemyState  _currentState;

   public void SetState(IEnemyState newState)
   {
      _currentState = newState;
      _currentState.OnEnter();
   }

   public void UpdateState()
   {
      _currentState.UpdateState();
   }
}
