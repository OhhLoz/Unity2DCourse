using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] int health = 200;

    [Header("Player Attack")]
    [SerializeField] float laserSpeed = 20f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float timeBetweenLasers = 0.1f;
    [SerializeField] AudioClip playerAttackSound;
    [SerializeField] [Range(0,1)] float attackSoundVolume = 0.3f;

    [Header("Player Death")]
    [SerializeField] AudioClip playerDeathSound;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.5f;

    private Vector3 spriteSize;
    private Camera gameCamera;
    private float xMin, xMax, yMin, yMax;

    Coroutine firingCoroutine;

	// Use this for initialization
	void Start ()
	{
        gameCamera = Camera.main;
        spriteSize = GetComponent<SpriteRenderer>().bounds.extents;
        SetPlayerMovementBoundaries();
	}

    // Update is called once per frame
    void Update ()
	{
        MovePlayer();
        FireLaser();
        //StartCoroutine(FireContinously());
	}

    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y + spriteSize.y), Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            AudioSource.PlayClipAtPoint(playerAttackSound, Camera.main.transform.position, attackSoundVolume);
            yield return new WaitForSeconds(timeBetweenLasers);
        }
    }

    public int GetHealth()
    {
        return health;
    }

    private void FireLaser()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    private void MovePlayer()
    {
        // Calculate X
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = transform.position.x + deltaX;
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        // Calculate Y
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y + deltaY;
        newYPos = Mathf.Clamp(newYPos, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetPlayerMovementBoundaries()
    {
        xMin = gameCamera.ViewportToWorldPoint(Vector3.zero).x + spriteSize.x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - spriteSize.x;
        yMin = gameCamera.ViewportToWorldPoint(Vector3.zero).y + spriteSize.y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - spriteSize.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health <= 0)
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, deathSoundVolume);
            FindObjectOfType<Level>().LoadGameOver();
        }
    }
}
