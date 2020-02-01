using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
	public Rigidbody2D _playerRigidbody;

	[SerializeField] private float _runSpeed = 5f;

	void Start()
	{
		_playerRigidbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		Run();
	}



	private void Run()
	{
		float horizontalControlThrow = Input.GetAxis("Horizontal"); //value is between -1 to +1

		if (horizontalControlThrow != 0)
		{
			Vector2 playerVelocity = new Vector2(horizontalControlThrow * _runSpeed, 0); //velocity is measured in units per second
			_playerRigidbody.velocity = playerVelocity;
		}
		else
		{
			float verticalControlThrow = Input.GetAxis("Vertical"); //value is between -1 to +1
			Vector2 playerVelocity = new Vector2(0, verticalControlThrow * _runSpeed); //velocity is measured in units per second
			_playerRigidbody.velocity = playerVelocity;
		}



		//Set Animation State
		//bool playerHasHorizontalSpeed = Mathf.Abs(_playerRigidbody.velocity.x) > Mathf.Epsilon;
		//_playerAnimator.SetBool("Running", playerHasHorizontalSpeed);
		//_playerAnimatorGlow.SetBool("Running", playerHasHorizontalSpeed);

	}
}
