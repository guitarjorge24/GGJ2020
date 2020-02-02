using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public static float timer;
    public float visibleTimer;

    private void Start()
    {
        timer = 400;
    }
    private void Update()
    {
        if (PauseScript.isGameActive == true)
        {
            timer -= Time.deltaTime;
            visibleTimer = timer;
        }
        if (timer < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
