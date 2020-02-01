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

            playerMove.enabled = false;
        }
    }

    IEnumerator SnareTimer(MovementController playerMove)
    {
        playerMove.enabled = false;
        yield return new WaitForSeconds(snareTimer);
        playerMove.enabled = true;
    }

}
