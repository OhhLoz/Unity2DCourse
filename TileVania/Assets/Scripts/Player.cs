using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
	// Config
	[SerializeField] float moveSpeed = 1f;
	[SerializeField] float climbVelocity = 2f;
	[SerializeField] float jumpVelocity = 2f;
	[SerializeField] float lowJumpVelocity = 1.5f;
	[SerializeField] float fallMultiplier = 2.5f;
	[SerializeField] Vector2 deathKick = new Vector2(12f,12f);

	// States
	bool isAlive = true;
	bool isClimbing = false;

	// Caches
	Rigidbody2D playerRigidbody;
	SpriteRenderer playerSpriteRenderer;
	Animator playerAnimator;
	Collider2D playerCollider;
	float initGravity;

	// Use this for initialization
	void Start()
	{
		playerRigidbody = GetComponent<Rigidbody2D>();
		playerSpriteRenderer = GetComponent<SpriteRenderer>();
		playerAnimator = GetComponent<Animator>();
		playerCollider = GetComponent<Collider2D>();
		initGravity = playerRigidbody.gravityScale;
	}

	// Update is called once per frame
	void Update()
	{
		if (!isAlive) { return; }
		Run();
		Jump();
		ClimbLadder();
		Die();
	}

	private void Run()
	{
        //var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        //var newXPos = transform.position.x + deltaX;

        //transform.position = new Vector2(newXPos, transform.position.y);

		float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		Vector2 playerVelocity = new Vector2(controlThrow * moveSpeed, playerRigidbody.velocity.y);
		playerRigidbody.velocity = playerVelocity;

		//Handles flipping of the sprite when moving left and right
		if (controlThrow < 0)
		{
			playerSpriteRenderer.flipX = true;
			playerAnimator.SetBool("Sprinting", true);
		}
		else if (controlThrow > 0)
		{
			playerSpriteRenderer.flipX = false;
			playerAnimator.SetBool("Sprinting", true);
		}
		else
		{
			playerAnimator.SetBool("Sprinting", false);
		}
	}

	private void Jump()
	{
		if (CrossPlatformInputManager.GetButtonDown("Jump") && CheckGround())
		{
			playerRigidbody.velocity = Vector2.up * jumpVelocity;
		}

		// Better Jump Code, to make falling faster, and can tap the button for a small jump and hold for a large jump
		if (playerRigidbody.velocity.y < 0)
			playerRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		else if (playerRigidbody.velocity.y > 0 && !CrossPlatformInputManager.GetButton("Jump"))
			playerRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
	}

	private bool CheckGround()
	{
 		RaycastHit2D hit = Physics2D.Raycast(playerRigidbody.transform.position, Vector2.down,0.55f, LayerMask.GetMask("Ground"));
		return (hit.collider != null);
	}

	private void ClimbLadder()
	{
		if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
		{
			float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
			Vector2 climbVelocityVector = new Vector2(playerRigidbody.velocity.x, controlThrow * climbVelocity);
			playerRigidbody.velocity = climbVelocityVector;
			playerRigidbody.gravityScale = 0;
			playerAnimator.SetBool("Climbing", true);
		}
		else
		{
			playerRigidbody.gravityScale = initGravity;
			playerAnimator.SetBool("Climbing", false);
		}
	}

	private void Die()
	{
		if(playerCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
		{
			isAlive = false;
			playerAnimator.SetTrigger("Dying");
			playerRigidbody.velocity = deathKick;
			FindObjectOfType<GameSession>().ProcessPlayerDeath();
		}
	}

	public bool getAliveState() { return isAlive; }
}
