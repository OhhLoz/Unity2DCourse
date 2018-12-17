using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
	int score = 0;
	// Use this for initialization

	private void Awake()
	{
		int noOfGameSessions = FindObjectsOfType<GameSession>().Length;
		if (noOfGameSessions > 1)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	public int GetScore()
	{
		return score;
	}

	public void AddToScore(int addition)
	{
		score += addition;
	}

	public void ResetGame()
	{
		Destroy(gameObject);
	}
}
