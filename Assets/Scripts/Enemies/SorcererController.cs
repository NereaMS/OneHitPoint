using UnityEngine;

public class SorcererController : EnemyController
{
    
    public float fireCoolDown = 2f; //para que no parezca una metralleta
    protected override void Start()
    {
        base.Start();
        StateMachine = new EnemyStateMachine();
        StateMachine.Initialize(this);
        StateMachine.SetState(new StaticAttackState(this, StateMachine));

    }
}
