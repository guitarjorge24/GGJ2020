using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SnareTrap : Trap
{
    public float playerSnareTimer = 2;
    public float janitorSnareTimer = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MovementController playerMove = collision.GetComponent<MovementController>();
            StartCoroutine(SnareTimer(playerMove));
        }
        else if (collision.CompareTag("Janitor"))
        {
			AIPath janitorMovement = collision.GetComponent<AIPath>();
            StartCoroutine(JanitorSnareTimer(janitorMovement));
			//#ToDo: play janitor snare animation
        }
    }

    IEnumerator JanitorSnareTimer(AIPath janitorMovement)//JanitorController janitorController)
    {
		janitorMovement.enabled = false;
        yield return new WaitForSeconds(janitorSnareTimer);
		janitorMovement.enabled = true;
	}

	IEnumerator SnareTimer(MovementController playerMove)
    {
        playerMove.enabled = false;
		playerMove.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //necessary to prevent player from continuing to go off on the last direction it was moving (like ice floor)
        yield return new WaitForSeconds(playerSnareTimer);
        playerMove.enabled = true;
    }

}
