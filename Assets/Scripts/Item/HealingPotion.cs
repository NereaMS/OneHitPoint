using UnityEngine;

public class HealingPotion : MonoBehaviour
{
   private float _duration = 20f;// 1 minuto

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
         if (playerHealth != null)
         {
            playerHealth.AddTemporaryHeart(_duration);
            
         }
         Destroy(gameObject);
            
      }
   }
}
