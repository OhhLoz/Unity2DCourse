using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
	[SerializeField] int stars = 100;
	Text starText;
	// Use this for initialization
	void Start()
	{
		starText = GetComponent<Text>();
		UpdateDisplay();
	}

	private void UpdateDisplay()
	{
		starText.text = stars.ToString();
	}

	public void AddStars(int starAmount)
	{
		stars += starAmount;
		UpdateDisplay();
	}

	public void RemoveStars(int starAmount)
	{
		if (stars >= starAmount)
		{
			stars -= starAmount;
			UpdateDisplay();
		}
	}
}
