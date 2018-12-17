using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	// Use this for initialization
	int currentSceneIndex;
	[SerializeField] int timeToWait = 3;

	void Start ()
	{
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		if(currentSceneIndex == 0)
		{
			StartCoroutine(WaitForTime(timeToWait));
		}

	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void LoadNextScene(int currScene)
	{
		SceneManager.LoadScene(currScene + 1);
	}

	IEnumerator WaitForTime(int waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		LoadNextScene(currentSceneIndex);
	}
}
