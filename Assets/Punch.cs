using System.Collections;
using UnityEngine;
using Pathfinding;

public class Punch : MonoBehaviour
{
	[SerializeField]
	private int punchStrenght = 5;

	//private
	private bool isEnemyinPunchZone;
	private GameObject enemy;


	//cached
	MovementController playerMovement;

	//public
	public CircleCollider2D punchUpCollider;
	public CircleCollider2D punchDownCollider;
	public CircleCollider2D punchLeftCollider;
	public CircleCollider2D punchRightCollider;


	void Start()
	{
		playerMovement = GetComponentInParent<MovementController>();
	}


	void Update()
	{
		//Debug.Log(playerMovement.playerDirection);
		SelectPunchDirection();
	}

	private void SelectPunchDirection()
	{
		if (Input.GetButtonDown("Punch"))
		{
			

			switch (playerMovement.playerDirection)
			{
				case MovementController.facingDirection.up:
					StartCoroutine(PunchAttack(punchUpCollider, Vector2.up));
					//play punch up animation too
					break;
				case MovementController.facingDirection.down:
					StartCoroutine(PunchAttack(punchDownCollider, Vector2.down));
					break;
				case MovementController.facingDirection.left:
					StartCoroutine(PunchAttack(punchLeftCollider, Vector2.left));
					break;
				case MovementController.facingDirection.right:
					StartCoroutine(PunchAttack(punchRightCollider, Vector2.right));
					break;
			}


		}

	}

	private IEnumerator PunchAttack(CircleCollider2D punchCollider, Vector2 punchForce)
	{
		punchCollider.enabled = true;

		yield return new WaitForSeconds(0.1f);

		if (isEnemyinPunchZone)
		{
			Debug.Log("punched up " + enemy.name);
			enemy.GetComponent<AIPath>().enabled = false;
			enemy.GetComponent<Rigidbody2D>().AddForce(punchForce * punchStrenght, ForceMode2D.Impulse);
			//enemy.GetComponent<Rigidbody2D>().velocity = punchForce * punchStrenght;
			yield return new WaitForSeconds(0.5f);
			enemy.GetComponent<AIPath>().enabled = true;
		}
		punchCollider.enabled = false;

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("OnTriggerEnter with layer: " + LayerMask.LayerToName(collision.gameObject.layer));

		//Debug.Log("is " + LayerMask.LayerToName(collision.gameObject.layer) + "the same as " + LayerMask.LayerToName(LayerMask.GetMask("Enemy"))); // no, it's not. ONe returns '10' and the other '1024'

		if (((1 << collision.gameObject.layer) & LayerMask.GetMask("Enemy")) != 0){
			Debug.Log("Enemy OnTriggerEnter!!!");
			isEnemyinPunchZone = true;
			enemy = collision.gameObject;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.GetMask("Enemy"))
		{
			isEnemyinPunchZone = true;
			enemy = collision.gameObject;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		//Debug.Log("OnTriggerExit");

		isEnemyinPunchZone = false;
	}

}
