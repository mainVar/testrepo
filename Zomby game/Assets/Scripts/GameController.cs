using UnityEditor;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    [Inject]
    private UIController uiController;
    [Inject]
    private GameConfig confController;
    // [Inject]
    [Inject]
    private ProtectedArea protectedArea;

    private bool status;
    [SerializeField]
    private Touchcontroller touchcontroller;
    public void Play() //crete zomby and other
    {
        
        uiController.HideMenuPanel();
        confController.GameStatus = true;
      
    }
    
    void Update()
    {
        if (protectedArea.MissUnit == 3)
        {
            uiController.ShowRestartPanel();
            confController.GameStatus = false;
            Restart();
        }
    }
    public void Restart()
    {
        uiController.HideRestartPanel();
        uiController.HideMenuPanel();
        confController.GameStatus = false;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        confController.GameStatus = false;
        EditorApplication.isPlaying = false;

#else
        confController.GameStatus = false;
        Application.Quit();
#endif
    }
}

