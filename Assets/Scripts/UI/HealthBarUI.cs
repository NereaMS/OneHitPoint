using UnityEngine;
using UnityEngine.UIElements;

public class HealthBarUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Texture2D fullHeart;
    public Texture2D emptyHeart;
    
    private VisualElement[] _hearts;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var screen = GetComponent<UIDocument>().rootVisualElement;
        
        int numHearts = playerHealth.maxHealth;
        _hearts = new VisualElement[numHearts];
        for (int i = 0; i < numHearts; i++)
        {
            _hearts[i]= screen.Q<VisualElement>($"heart{i+1}");
        }

        playerHealth.OnHealthChanged+= UpdateHearts;
    }

    // Update is called once per frame
    void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            Texture2D heart = i < currentHealth ? fullHeart : emptyHeart;
            _hearts[i].style.backgroundImage = new StyleBackground(heart);
        }
    }
}
