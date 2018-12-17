using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
	bool spawn = true;
	[SerializeField] float maxSpawnTime = 5f;
	[SerializeField] float minSpawnTime = 1f;

	[SerializeField] Attacker attackerToSpawn;
	// Use this for initialization
	IEnumerator Start()
	{
		while(spawn)
		{
			yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
			SpawnAttacker();
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void SpawnAttacker()
	{
		Attacker instantiated = Instantiate(attackerToSpawn, transform.position, Quaternion.identity);
	}
}
