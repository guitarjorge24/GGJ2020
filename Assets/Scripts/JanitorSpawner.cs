using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanitorSpawner : MonoBehaviour
{
    public GameObject janitorPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject janitor = Instantiate(janitorPrefab) as GameObject;
            janitor.transform.position = transform.position;

            Destroy(gameObject);
        }
    }

}
