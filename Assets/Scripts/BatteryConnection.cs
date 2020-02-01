using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class BatteryConnection : MonoBehaviour
{

    public GameObject connectsWith;

    private void Start()
    {
        if (!connectsWith)
        {
            Debug.LogError("You did not create a connection game object in the inspector panel for this battery connector.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == connectsWith)
        {
            OnBatteryConnected();
        }
    }

    private void OnBatteryConnected()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load next level
    }

}
