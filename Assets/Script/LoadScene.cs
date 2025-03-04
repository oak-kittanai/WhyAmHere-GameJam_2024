using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public SceneManager sceneManager;

    public void LoadASceneGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadASceneMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadASceneEnd()
    {
        SceneManager.LoadScene("End");
    }
    public void LoadASceneAnim()
    {
        SceneManager.LoadScene("Anim");
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
