using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
	[SerializeField] GameObject defenderPrefab;

	private void OnMouseDown()
	{
		Debug.Log("Mouse Clicked");
		SpawnDefender(GetSquareClicked());
	}

	private Vector2 GetSquareClicked()
	{
		Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
		Vector2 gridPos = SnapToGrid(worldPos);
		return gridPos;
	}

	private Vector2 SnapToGrid(Vector2 rawWorldPos)
	{
		int newX = Mathf.RoundToInt(rawWorldPos.x);
		int newY = Mathf.RoundToInt(rawWorldPos.y);

		return new Vector2(newX, newY);
	}

	private void SpawnDefender(Vector2 squarePos)
	{
		GameObject spawnedDefender = Instantiate(defenderPrefab, squarePos, Quaternion.identity);
		Debug.Log("Spawned Defender at " + squarePos);
	}
}
