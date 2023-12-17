using UnityEngine;
using UnityEngine.SceneManagement;


public enum Scene
{
    MainMenu,
    Controls,
    Tutorial,
    LevelOne,
    LevelTwo,
    LevelThree,
    NewGamePlus
}

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene((int)Scene.LevelOne);
    }

    public void NewGamePlus()
    {
        SceneManager.LoadScene((int)Scene.NewGamePlus);
    }

    public void ControlsOption()
    {
        SceneManager.LoadScene((int)Scene.Controls);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene((int)Scene.Tutorial);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
