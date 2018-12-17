using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	Rigidbody2D enemyRigidBody;
	[SerializeField] float moveSpeed = 1f;
	float distanceToWall = 0.3f;
	float distanceToFloor = 1f;
	SpriteRenderer enemySprite;
	// Use this for initialization
	void Start()
	{
		enemyRigidBody = GetComponent<Rigidbody2D>();
		enemySprite = GetComponent<SpriteRenderer>();
		enemyRigidBody.velocity = new Vector2(moveSpeed, 0f);
	}

	// Update is called once per frame
	void Update()
	{
		Move();
	}

	void Move()
	{
		SwitchDirection();
		//Vector2 newPosition = new Vector2(enemyRigidBody.transform.position.x + enemyRigidBody.transform.localScale.x * Time.deltaTime, enemyRigidBody.transform.position.y);
		//enemyRigidBody.MovePosition(newPosition);
	}

	void SwitchDirection()
	{
		bool isFacingWall = false;
		Vector2 edgeOfCharacter = Vector2.zero;

		if (enemyRigidBody.velocity.x >= 0)
		{
			isFacingWall = Physics2D.Raycast(enemyRigidBody.transform.position, Vector2.right, distanceToWall, LayerMask.GetMask("Ground"));
			edgeOfCharacter = new Vector2(enemyRigidBody.transform.position.x + enemySprite.bounds.extents.x, enemyRigidBody.transform.localPosition.y);
		}
		else if (enemyRigidBody.velocity.x < 0)
		{
			isFacingWall = Physics2D.Raycast(enemyRigidBody.transform.position, Vector2.left, distanceToWall, LayerMask.GetMask("Ground"));
			edgeOfCharacter = new Vector2(enemyRigidBody.transform.position.x - enemySprite.bounds.extents.x, enemyRigidBody.transform.localPosition.y);
		}

		bool isStandingOnGround = Physics2D.Raycast(edgeOfCharacter, Vector2.down, distanceToFloor, LayerMask.GetMask("Ground"));

		if (isFacingWall || !isStandingOnGround)
		{
			//enemyRigidBody.transform.localScale = new Vector2(enemyRigidBody.transform.localScale.x * -1, enemyRigidBody.transform.localScale.y);
			enemySprite.flipX = !enemySprite.flipX;
			enemyRigidBody.velocity = new Vector2(-enemyRigidBody.velocity.x, 0f);
		}
	}
}
