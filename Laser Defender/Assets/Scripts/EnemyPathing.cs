using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour 
{
    WaveConfig waveConfig;

    List<Transform> pathWaypoints;
    int wayPointIndex = 0;
    float moveSpeed;

	// Use this for initialization
	void Start() 
	{
        pathWaypoints = waveConfig.getPathWaypoints();
        transform.position = pathWaypoints[wayPointIndex].position;
        moveSpeed = waveConfig.getEnemyMoveSpeed();
    }
	
	// Update is called once per frame
	void Update() 
	{
        if (wayPointIndex <= pathWaypoints.Count - 1)
        {
            var targetPos = pathWaypoints[wayPointIndex].position;
            targetPos[2] = 0;
            var movementPerFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, movementPerFrame);

            if (transform.position == targetPos)
                wayPointIndex++;
        }
        else
            Destroy(gameObject);
	}

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }
}
