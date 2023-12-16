using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene((int)Scene.MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene((int)Scene.MainMenu);

        }
    }
}
