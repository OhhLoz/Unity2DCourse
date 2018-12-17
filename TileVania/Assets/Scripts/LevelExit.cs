using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
	[SerializeField] float LevelLoadDelay = 4f;
	[SerializeField] float LevelExitSlowMotionFactor = 0.25f;
	int currSceneIndex;

	private void OnTriggerEnter2D(Collider2D other)
	{
		Player playerTest = other.GetComponent<Player>();
		if (playerTest != null && playerTest.getAliveState())
		{
			if(SceneManager.GetActiveScene().name == "Success")
				currSceneIndex = -1;
			else
				currSceneIndex = SceneManager.GetActiveScene().buildIndex;
			StartCoroutine(ExitLevel());
		}
	}

	IEnumerator ExitLevel()
	{
		Time.timeScale = LevelExitSlowMotionFactor;
		GetComponent<AudioSource>().Play();
		yield return new WaitForSecondsRealtime(LevelLoadDelay);
		Time.timeScale = 1f;
		SceneManager.LoadScene(++currSceneIndex);
	}
}
