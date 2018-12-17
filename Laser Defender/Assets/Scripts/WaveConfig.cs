using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float timeVariation = 0.3f;
    [SerializeField] int noOfEnemies = 5;
    [SerializeField] float enemyMoveSpeed = 2f;

    public GameObject getEnemyPrefab() { return enemyPrefab; }

    public List<Transform> getPathWaypoints()
    {
        var pathWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
            pathWaypoints.Add(child);
        return pathWaypoints;
    }

    public float getTimeBetweenSpawns() { return timeBetweenSpawns; }

    public float getTimeVariation() { return timeVariation; }

    public int getNoOfEnemies() { return noOfEnemies; }

    public float getEnemyMoveSpeed() { return enemyMoveSpeed; }
}
