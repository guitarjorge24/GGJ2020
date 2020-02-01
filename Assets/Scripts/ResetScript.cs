using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour
{
    private int sceneMemory, resetCount; //for later and tracking resets
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Reset"))
        {
            //begin resetting
            //code to get scene where reset occured, just in case;
            sceneMemory = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
