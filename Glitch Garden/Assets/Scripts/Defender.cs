using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour 
{
	[SerializeField] int starCost = 100;

	public void AddStars(int amountToAdd)
	{
		StarDisplay temp = FindObjectOfType<StarDisplay>();
		if(temp != null)
		{
			Debug.Log("Adding Stars");
			temp.AddStars(amountToAdd);
		}
			
	}
}
