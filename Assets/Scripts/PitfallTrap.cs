using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitfallTrap : Trap
{
    private Vector2 startPosition;
    private SpriteRenderer spriteRenderer;
    public Sprite TrapWithJanitor;
    private bool trapEnabled = true;
	private Animator _playerAnimator;

	void Start()
    {
        startPosition = GameObject.FindWithTag("StartPoint").transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
		_playerAnimator = GetComponent<Animator>();

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!trapEnabled)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = startPosition;
        }
		else if (collision.gameObject.CompareTag("Janitor"))
		{
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            spriteRenderer.sprite = TrapWithJanitor;
            trapEnabled = false;
		}
    }

}
