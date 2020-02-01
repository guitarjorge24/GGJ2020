using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
[ExecuteAlways]
public class BatteryConnection : MonoBehaviour
{

    public GameObject connectsWith;
    public Sprite BatterySprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (!connectsWith)
        {
            Debug.LogError("You did not create a connection game object in the inspector panel for this battery connector.");
        }
    }

    private void Update()
    {
        if (spriteRenderer && spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = BatterySprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
