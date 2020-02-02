using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public string batteryString;
    public Text timerText;
    public Slider batteryBar;
    public Image batteryIcon, batteryBarFill;

    // Update is called once per frame
    void Update()
    {
        batteryBar.value = GameState.timer / 400;
        if(PauseScript.isGameActive == true)
        {
            batteryString = GameState.timer.ToString("F0");
            timerText.text = batteryString;
            if(GameState.timer < 100)
            {
                batteryIcon.color = Color.red;
                batteryBarFill.color = Color.red;
            }
        }
    }
}
