using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool isGameActive = true;
    public GameObject pauseMenuObject;
   
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive == true)
        {
            if (Input.GetKeyUp("escape"))
            {
                isGameActive = false;
                pauseMenuObject.SetActive(true);
            }
        }  
        else if (isGameActive == false)
        {
            if (Input.GetKeyUp("escape"))
            {
                ContinueGame();
            }
        }
    }
    public void ContinueGame()
    {
        isGameActive = true;
        pauseMenuObject.SetActive(false);
    }

    public void ReturnToMenu()
    {
        isGameActive = true;
        SceneManager.LoadScene("MainMenu");
    }
}
