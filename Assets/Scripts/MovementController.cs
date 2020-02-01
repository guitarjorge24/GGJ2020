using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
   [SerializeField]
    private GameObject playerChar;

    private float upDown = 0;
    private float leftRight = 0;
    public bool UpOrDownFacing, isRight, isUp = true;
    //updates on fixed intervals, NOT FRAMERATE DEPENDANT
    void FixedUpdate()
    {
        //get input
        upDown = Input.GetAxis("Vertical");
        leftRight = Input.GetAxis("Horizontal");
        //move in all 4 directions
        transform.Translate(Vector3.up *(upDown * 0.1f));
        transform.Translate(Vector3.right * (leftRight *0.1f));
        //logic for most recent direction for use in animation
        if(upDown > 0)
        {
            UpOrDownFacing = true;
            isUp = false;
        }
        if (upDown > 0)
        {
            UpOrDownFacing = true;
            isUp = false;
        }
        if (leftRight > 0)
        {
            UpOrDownFacing = false;
            isRight = false;
        }
        if (leftRight < 0)
        {
            UpOrDownFacing = false;
            isRight = true;
        }
    }
}
