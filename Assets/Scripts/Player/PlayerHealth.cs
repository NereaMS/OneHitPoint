
/*Clase encargada de la salud y el dano del Player*/

using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    
    public UIDocument uiDoc;
    public Sprite fullHeart;
    
    public Sprite emptyHeart;

    public int currentHealth;
    public int maxHealth = 3;
    
    private VisualElement[] _hearts;
    
    
    
    
    private void OnEnable()
    {
        var root = uiDoc.rootVisualElement;
        
       
        _hearts = new VisualElement[maxHealth];
        for (int i = 0; i < maxHealth; i++)
        {
           _hearts[i] = root.Q<VisualElement>($"Heart{i+1}");
           if(_hearts[i] == null)
               Debug.Log("No heart");
        }
        DrawHearts();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        DrawHearts();
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    
   void DrawHearts()
   {
        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                _hearts[i].style.backgroundImage = new StyleBackground(fullHeart.texture);
            }
            else
            {
              _hearts[i].style.backgroundImage = new StyleBackground(emptyHeart.texture);
            }
        }
    }

    void OnHealthChanged(int health)
    {
        
    }
}
