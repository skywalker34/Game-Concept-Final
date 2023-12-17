using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    public GameObject levelChanger;
    public GameComplete gameComplete;

    private void OnTriggerEnter(Collider other)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == (int)Scene.LevelThree || currentScene == (int)Scene.NewGamePlus)
        {
            gameComplete.GetComponent<GameComplete>().gameCompleteUI.SetActive(true);
        }
        else
        {
            levelChanger.GetComponent<LevelChanger>().LevelComplete();
        }
    }
}
