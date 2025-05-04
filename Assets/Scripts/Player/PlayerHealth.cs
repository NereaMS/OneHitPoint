
/*Clase encargada de la salud y el dano del Player*/

using System;
using System.Collections;
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
            GameOverUI.Instance.Show();
            gameObject.SetActive(false);//Oculta el jugador sin destruirlo.
        }
    }
    public void AddTemporaryHeart(float duration)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += 1;
            OnHealthChanged?.Invoke(currentHealth);
            StartCoroutine(RemoveTemporaryHeartAfter(duration));
        }
    }

   private IEnumerator RemoveTemporaryHeartAfter(float duration)
   {
       yield return new WaitForSeconds(duration);//Espera la cantidad de segundos que se le pasa por parametro
       
       currentHealth = Mathf.Max(0, currentHealth -1);
       OnHealthChanged?.Invoke(currentHealth);
   }
   
   void Update()
   {
       if (Input.GetKeyDown(KeyCode.L))
       {
           TakeDamage(1);
       }
   }
   
}
