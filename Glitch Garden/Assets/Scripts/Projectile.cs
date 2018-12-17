using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] float projectileSpeed = 1f;
	[SerializeField] bool isRotate = false;
	[SerializeField] float rotateSpeed = 10f;

	[SerializeField] int projectileDamage = 50;
	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		//transform.position += Vector3.right * projectileSpeed * Time.deltaTime;
		transform.Translate(Vector3.right * projectileSpeed * Time.deltaTime, Space.World);
		if (isRotate)
			transform.Rotate(-Vector3.forward, rotateSpeed * Time.deltaTime);
	}

	public int GetDamage() { return projectileDamage; }

	private void OnTriggerEnter2D(Collider2D other)
	{
		var health = other.GetComponent<Health>();
		var attacker = other.GetComponent<Attacker>();
		if (health && attacker)
		{
			health.DealDamage(projectileDamage);
			Destroy(gameObject);
		}
	}
}
