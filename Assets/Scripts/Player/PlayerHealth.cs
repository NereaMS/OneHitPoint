
/*Clase encargada de la salud y el dano del Player*/

using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    public PlayerController player;
    public UIDocument uiDoc;
    private Label m_HealthLabel;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
        PlayerController.OnHealthChange += HealthChanged;
        m_HealthLabel = uiDoc.rootVisualElement.Q<Label>("Health");
        HealthChanged();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HealthChanged()
    {
        m_HealthLabel.text = $"{PlayerController.CurrentHealth}/{PlayerController.MaxHealth}";
        
    }

    void OnHealthChanged(int health)
    {
        
    }
}
