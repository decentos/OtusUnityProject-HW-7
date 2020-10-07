using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    enum Screen
    {
        None,
        Main,
        Settings,
        Levels
    }

    public CanvasGroup mainScreen;
    public CanvasGroup settingsScreen;
    public CanvasGroup levelScreen;

    void SetCurrentScreen(Screen screen)
    {
        Utility.SetCanvasGroupEnabled(mainScreen, screen == Screen.Main);
        Utility.SetCanvasGroupEnabled(settingsScreen, screen == Screen.Settings);
        Utility.SetCanvasGroupEnabled(levelScreen, screen == Screen.Levels);
    }

    void Awake()
    {
        SetCurrentScreen(Screen.Main);
    }

    public void OpenLevels()
    {
        SetCurrentScreen(Screen.Levels);
    }

    public void LoadFirstLevel()
    {
        SetCurrentScreen(Screen.None);
        LoadingScreen.instance.LoadScene("Level_1");
    }

    public void LoadSecondLevel()
    {
        SetCurrentScreen(Screen.None);
        LoadingScreen.instance.LoadScene("Level_2");
    }
    
    public void OpenSettings()
    {
        SetCurrentScreen(Screen.Settings);
    }

    public void CloseSettings()
    {
        SetCurrentScreen(Screen.Main);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
