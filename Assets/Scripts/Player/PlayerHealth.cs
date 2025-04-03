
/*Clase encargada de la salud y el dano del Player*/

using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    
    public UIDocument uiDoc;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    public int currentHealth = 1;
    public int maxHealth = 12;
    
    private VisualElement _healthContainer;
    private Label _mHealthLabel;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        var root = uiDoc.rootVisualElement;
        
       
        _healthContainer = uiDoc.rootVisualElement.Q<VisualElement>("HealthContainer");
        _mHealthLabel = uiDoc.rootVisualElement.Q<Label>("Health");

       // DrawHearts();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        //DrawHearts();
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    /*void DrawHearts()
    {
        int totalHearts =maxHealth;
        int  currentHearts = currentHealth;
        
        for(int i=0; i<totalHearts; i++)
            
        
        
        
    }

    void OnHealthChanged(int health)
    {
        
    }*/
}
