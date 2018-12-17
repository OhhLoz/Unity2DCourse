using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
	float currMoveSpeed = 1f;

	void Update ()
	{
		transform.Translate(Vector2.left * Time.deltaTime * currMoveSpeed);
	}

	public void SetMovementSpeed(float newSpeed)
	{
		currMoveSpeed = newSpeed;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
	}
}
