using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScenes : MonoBehaviour
{
    private int currentScene;
    public void LoadNextScene()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
    public void LoadMenuPrincipal()
    {

        SceneManager.LoadScene("IntroScene");
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void LoadPresentation()
    {
        SceneManager.LoadScene("presentation");
    }
}
