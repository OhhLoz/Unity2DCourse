using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatusScript : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int currScore = 0;
    [SerializeField] int scorePerBlockDestroyed = 50;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] bool isAutoPlay;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatusScript>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        scoreText.text = "Score: " + currScore;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Time.timeScale = gameSpeed;
	}

    public void updateScore()
    {
        currScore += scorePerBlockDestroyed;
        scoreText.text = "Score: " + currScore;
    }

    public void resetGame()
    {
        Destroy(gameObject);
    }

    public bool isAutoPlayEnabled()
    {
        return isAutoPlay;
    }
}
