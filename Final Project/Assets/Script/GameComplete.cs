using UnityEngine;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{
    public GameObject gameCompleteUI;
    public void MainMenu()
    {
        SceneManager.LoadScene((int)Scene.MainMenu);
    }
}
