using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    int nextLevel;

    public void LevelComplete()
    {
        animator.SetTrigger("FadeOut");
    }

    public void FadeComplete()
    {
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextLevel);
    }
}
