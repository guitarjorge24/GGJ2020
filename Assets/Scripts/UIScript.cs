using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public string BatteryString;
    public Text timerText;

    // Update is called once per frame
    void Update()
    {
        if(PauseScript.isGameActive == true)
        {
            BatteryString = GameState.timer.ToString("F0");
            timerText.text = BatteryString;
        }
    }
}
