using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverUI : MonoBehaviour
{
   public static GameOverUI Instance;
   
   private VisualElement _screen;
   
   private void Awake()
   {
      Instance = this;
   }
   
   private void Start()
   {
      _screen = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>("GameOverScreen");//Cargamos el panel de GameOver
      _screen.style.display = DisplayStyle.None;//Ocultamos el panel de GameOver

      var retryButton = _screen.Q<Button>("retryButton");
      var restartButton = _screen.Q<Button>("restartButton");
      var quitButton = _screen.Q<Button>("quitButton");

      retryButton.clicked += () =>
      {
         Time.timeScale = 1f;
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      };
      
      restartButton.clicked += () =>
      {
         Time.timeScale = 1f;
         SceneManager.LoadScene("TitleScreen");
      };
      
      quitButton.clicked += () =>
      {
         Application.Quit();
        
      };
      
   }
   public void Show()
   {
      Time.timeScale = 0f;
      _screen.style.display = DisplayStyle.Flex;
   }
   
   
 
}
