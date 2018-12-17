using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
	TextMeshProUGUI healthText;
	PlayerMovementScript player;
	// Use this for initialization
	void Start ()
	{
		healthText = GetComponent<TextMeshProUGUI>();
		player = FindObjectOfType<PlayerMovementScript>();
	}

	// Update is called once per frame
	void Update ()
	{
		healthText.text = player.GetHealth().ToString();
	}
}
