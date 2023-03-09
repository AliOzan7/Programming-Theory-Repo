using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunctionality : MonoBehaviour
{
    public void QuitApp()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadDemoScene()
    {
        SceneManager.LoadScene(1);
    }
}
