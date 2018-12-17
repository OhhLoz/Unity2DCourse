using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
	int startingSceneIndex;
	private void Awake()
	{
		var noOfActive = FindObjectsOfType<ScenePersist>().Length;
		if(noOfActive > 1)
			Destroy(gameObject);
		else
			DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start()
	{
		startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
	}

	// Update is called once per frame
	void Update()
	{
		if(SceneManager.GetActiveScene().buildIndex != startingSceneIndex)
			Destroy(gameObject);
	}
}
