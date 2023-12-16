using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Scene
{
    MainMenu,
    Controls,
    Settings,
    ThirdPersonWithAimMode
}

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene((int)Scene.ThirdPersonWithAimMode);
    }

    public void ControlsOption()
    {
        SceneManager.LoadScene((int)Scene.Controls);
    }

    public void SettingsOption()
    {
        SceneManager.LoadScene((int)Scene.Settings);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
