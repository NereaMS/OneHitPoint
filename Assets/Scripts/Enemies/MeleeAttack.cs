using Unity.VisualScripting;
using UnityEngine;

public class MeleeAttack : MonoBehaviour, IAttackHandler
{
    
    private int _damage = 1;
    public void PerformAttack()
    {
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(_damage);
            
        }
            
        
    }
}
