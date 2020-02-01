using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public string BatteryString;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseScript.isGameActive == true)
        {
            BatteryString = GameState.timer.ToString("F2");

            timerText.text = BatteryString;
        }
    }
}
