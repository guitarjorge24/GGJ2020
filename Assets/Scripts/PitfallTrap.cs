using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitfallTrap : Trap
{
    private Vector2 startPosition;

    void Start()
    {
        startPosition = GameObject.FindWithTag("StartPoint").transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = startPosition;
        }
		else if (collision.gameObject.CompareTag("Janitor"))
		{
            collision.gameObject.SetActive(false);
		}
    }

}
