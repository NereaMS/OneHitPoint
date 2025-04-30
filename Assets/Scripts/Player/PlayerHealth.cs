
/*Clase encargada de la salud y el dano del Player*/

using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    
   

    public int currentHealth = 3;
    public int maxHealth = 3;
    
   
    
    public event Action<int> OnHealthChanged;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
       

       OnHealthChanged?.Invoke(currentHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth);
    }

   void Update()
   {
       if (Input.GetKeyDown(KeyCode.H))
       {
           TakeDamage(1);
       }
       if (Input.GetKeyDown(KeyCode.L))
       {
           Heal(1);
       }
   }

  
}
