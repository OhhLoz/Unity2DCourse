using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
	[SerializeField] int playerLives = 3;
	[SerializeField] int score = 0;
	[SerializeField] Text livesText;
	[SerializeField] Text scoreText;

	void Awake()
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

	// Use this for initialization
	void Start()
	{
		livesText.text = playerLives.ToString();
		scoreText.text = score.ToString();
	}

	public void ProcessPlayerDeath()
	{
		playerLives--;
		livesText.text = playerLives.ToString();
		if (playerLives <= 0)
		{
			ResetGameSession();
		}
		else //Load current scene
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void ProcessCoinPickup(int pointsToAdd)
	{
		score += pointsToAdd;
		scoreText.text = score.ToString();
	}

	private void ResetGameSession()
	{
		SceneManager.LoadScene(0);
		Destroy(gameObject);
	}
}
