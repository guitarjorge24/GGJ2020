using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load next level in build settings. 
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene(0); // Load Main Menu
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits"); // Load Credits Scene
    }

}
