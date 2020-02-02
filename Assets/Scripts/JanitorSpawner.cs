using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class JanitorSpawner : MonoBehaviour
{
    public GameObject janitorPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject janitor = Instantiate(janitorPrefab) as GameObject;
            janitor.transform.position = transform.position;
            AIDestinationSetter dest = janitor.GetComponent<AIDestinationSetter>();
            dest.target = collision.transform;

            Destroy(gameObject);
        }
    }

}
