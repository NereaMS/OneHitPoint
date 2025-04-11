using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TitleScreenUI : MonoBehaviour
{
   private void OnEnable()
   {
      var screen = GetComponent<UIDocument>().rootVisualElement;
      var startButton = screen.Q<Button>("startButton");
      var quitButton = screen.Q<Button>("quitButton");

      startButton.clicked += () =>
      {
         Time.timeScale = 1f;
         SceneManager.LoadScene("LevelTest");
      };

      quitButton.clicked += () =>
      {
         Application.Quit();
         Debug.Log("Quit");
         
      };
   }
}
