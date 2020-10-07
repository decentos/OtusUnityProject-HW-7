using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup gameMenu;
    [SerializeField] private CanvasGroup buttonsCanvasGroup;
    [SerializeField] private CanvasGroup finalPopup;

    private void Start()
    {
        Utility.SetCanvasGroupEnabled(@group: gameMenu, enabled: false);
        Utility.SetCanvasGroupEnabled(@group: finalPopup, enabled: false);
    }

    public void OpenMenu()
    {
        Utility.SetCanvasGroupEnabled(@group: gameMenu, enabled: true);
        Utility.SetCanvasGroupEnabled(@group: buttonsCanvasGroup, enabled: false);
    }

    public void Continue()
    {
        Utility.SetCanvasGroupEnabled(@group: gameMenu, enabled: false);
        Utility.SetCanvasGroupEnabled(@group: buttonsCanvasGroup, enabled: true);
    }

    public void Restart()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }       
}