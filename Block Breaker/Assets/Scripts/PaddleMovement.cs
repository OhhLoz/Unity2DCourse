using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] float screenUnitWidth = 16f;
    [SerializeField] float paddleMinX = 1.6f;
    [SerializeField] float paddleMaxX = 14.4f;

    Ball ball;
    GameStatusScript gameStatus;

    // Use this for initialization
    void Start ()
    {
        gameStatus = FindObjectOfType<GameStatusScript>();
        ball = FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(getXPos(), paddleMinX, paddleMaxX);
        transform.position = paddlePos;
	}
    
    private float getXPos()
    {
        if (gameStatus.isAutoPlayEnabled())
            return ball.transform.position.x;
        else
            return (Input.mousePosition.x / Screen.width) * screenUnitWidth;
    }
}
