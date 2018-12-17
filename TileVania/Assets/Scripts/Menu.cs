using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	public void StartFirstLevel()
	{
		SceneManager.LoadScene(1);
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene(0);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Collision Enter Detected");
		Image button = GetComponent<Image>();
		Color currButtonColor = button.color;
		currButtonColor.a = 0.7f;
		button.color = currButtonColor;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("Collision Exit Detected");
		Image button = GetComponent<Image>();
		Color currButtonColor = button.color;
		currButtonColor.a = 1f;
		button.color = currButtonColor;
	}
}
