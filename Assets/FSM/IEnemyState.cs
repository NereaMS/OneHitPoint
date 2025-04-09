using UnityEngine;

public interface IEnemyState
{
    void OnEnter();
    void UpdateState();
    void OnExit();
}
