using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
	public Rigidbody2D _playerRigidbody;


	public enum facingDirection {left, right, up, down};
	public facingDirection playerDirection;

	[SerializeField] private float _runSpeed = 5f;
	private Animator _playerAnimator;


	void Start()
	{
		_playerRigidbody = GetComponent<Rigidbody2D>();
		_playerAnimator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		Run();
		CheckFacingDirection();
	}



	private void Run()
	{
		float horizontalControlThrow = Input.GetAxis("Horizontal"); //value is between -1 to +1
		float verticalControlThrow = Input.GetAxis("Vertical"); //value is between -1 to +1

		if (horizontalControlThrow != 0)
		{
			Vector2 playerVelocity = new Vector2(horizontalControlThrow * _runSpeed, 0); //velocity is measured in units per second
			_playerRigidbody.velocity = playerVelocity;

			if (horizontalControlThrow > 0)
			{
				playerDirection = facingDirection.right;
			}
			else
			{
				playerDirection = facingDirection.left;

			}
		}
		else if (verticalControlThrow != 0)
		{
			Vector2 playerVelocity = new Vector2(0, verticalControlThrow * _runSpeed); //velocity is measured in units per second
			_playerRigidbody.velocity = playerVelocity;

			if (verticalControlThrow > 0)
			{
				playerDirection = facingDirection.up;

			}
			else
			{
				playerDirection = facingDirection.down;
				//_playerAnimator.SetBool

			}
		}
		else
		{
			_playerRigidbody.velocity = Vector2.zero;
		}



		//Set Animation State
		//bool playerHasHorizontalSpeed = Mathf.Abs(_playerRigidbody.velocity.x) > Mathf.Epsilon;
		//_playerAnimator.SetBool("Running", playerHasHorizontalSpeed);
		//_playerAnimatorGlow.SetBool("Running", playerHasHorizontalSpeed);

	}

	private void CheckFacingDirection()
	{

	}
}
