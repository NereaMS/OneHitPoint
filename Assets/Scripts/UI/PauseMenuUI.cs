using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenuUI : MonoBehaviour
{
    
    private VisualElement _screen;
    private bool _isPaused = false;
    
    private GameController _controls;

    private void Awake()
    {
        _controls = new GameController();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _screen = GetComponent<UIDocument>().rootVisualElement;
        _screen.style.display = DisplayStyle.None;
        
        var resumeButton = _screen.Q<Button>("resumeButton");
        var menuButton = _screen.Q<Button>("menuButton");
        var quitButton = _screen.Q<Button>("quitButton");

        resumeButton.clicked += () =>
        {
            _isPaused = false;
            Time.timeScale = 1f;
            _screen.style.display = DisplayStyle.None;
        };
        
        menuButton.clicked += () =>
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("TitleScreen");
        };
        quitButton.clicked += () =>
        {
            Application.Quit();
            Debug.Log("Quit");
        };

    }
    
    void OnEnable()
    {
       // _controls = new GameController();
        _controls.Enable();
        _controls.Player.Pause.performed += TogglePause;
        Debug.Log(_controls.Player.Pause);
    }

    private void OnDisable()
    {
        _controls.Player.Pause.performed -= TogglePause;
        _controls.Disable();
        Debug.Log(_controls.Player.Pause);
    }

    void TogglePause(InputAction.CallbackContext context)
    {
        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0f : 1f;
        _screen.style.display = _isPaused ? DisplayStyle.Flex : DisplayStyle.None;
    }
}
