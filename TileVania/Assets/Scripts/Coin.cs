using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	[SerializeField] int pointsToAdd = 50;
	private void OnTriggerEnter2D(Collider2D other)
	{
		FindObjectOfType<GameSession>().ProcessCoinPickup(pointsToAdd);
		AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, Camera.main.transform.position);
		Destroy(gameObject);
	}
}
