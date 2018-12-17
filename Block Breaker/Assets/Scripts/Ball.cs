using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] PaddleMovement paddle1;
    [SerializeField] float xLaunchVelocity = 2f;
    [SerializeField] float yLaunchVelocity = 15f;
    [SerializeField] AudioClip[] ballImpactSounds;

    [SerializeField] float randomFactor = 0.2f;

    [SerializeField] float ballSpeed = 10f;
    [SerializeField] float accelerator = 0.05f;

    private bool hasStarted = false;

    Vector2 paddleToBallVector;

    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

	// Use this for initialization
	void Start ()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            lockToPaddle();
            launchOnMouseClick();
        }
	}

    private void launchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(xLaunchVelocity, yLaunchVelocity);
            hasStarted = true;
        }
    }

    private void lockToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0, randomFactor), 
                                            UnityEngine.Random.Range(0, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballImpactSounds[UnityEngine.Random.Range(0, ballImpactSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
            myRigidBody2D.velocity = myRigidBody2D.velocity.normalized * ballSpeed;
            ballSpeed += accelerator;
        }  
    }
}
