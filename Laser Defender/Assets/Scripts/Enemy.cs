using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreOnKill = 150;
    [Header("Attack")]
    float shotTime;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] AudioClip enemyAttackSound;
    [SerializeField] [Range(0,1)] float attackSoundVolume = 0.3f;

    [Header("Death")]
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float deathVFXDuration = 1f;
    [SerializeField] AudioClip enemyDeathSound;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.5f;

    private Vector3 spriteSize;

    // Use this for initialization
    void Start ()
	{
        shotTime = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        spriteSize = GetComponent<SpriteRenderer>().bounds.extents;
    }

	// Update is called once per frame
	void Update ()
	{
        Shoot();
	}

    private void Shoot()
    {
        shotTime -= Time.deltaTime;
        if (shotTime <= 0f)
        {
            GameObject laser = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y - spriteSize.y), Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
            AudioSource.PlayClipAtPoint(enemyAttackSound, Camera.main.transform.position, attackSoundVolume);
            shotTime = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health <= 0)
            DestroyEnemy();
    }

    private void DestroyEnemy()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreOnKill);
        GameObject explosionObject = Instantiate(explosionPrefab, new Vector3(transform.position.x, transform.position.y), Quaternion.identity) as GameObject;
        Destroy(gameObject);
        Destroy(explosionObject, deathVFXDuration);
        AudioSource.PlayClipAtPoint(enemyDeathSound, Camera.main.transform.position, deathSoundVolume);
    }
}
