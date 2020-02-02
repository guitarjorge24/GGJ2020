using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnareTrap : Trap
{
    public float snareTimer = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MovementController playerMove = collision.GetComponent<MovementController>();
            StartCoroutine(SnareTimer(playerMove));
        }
        else if (collision.CompareTag("Janitor"))
        {
            //JanitorController janitorController = collision.GetComponent<JanitorController>();
            //StartCoroutine(JanitorSnareTimer(janitorController));
        }
    }
    IEnumerator JanitorSnareTimer()//JanitorController janitorController)
    {
        //playerMove.enabled = false;
        yield return new WaitForSeconds(snareTimer);
        //playerMove.enabled = true;
    }


    IEnumerator SnareTimer(MovementController playerMove)
    {
        playerMove.enabled = false;
        yield return new WaitForSeconds(snareTimer);
        playerMove.enabled = true;
    }

}
