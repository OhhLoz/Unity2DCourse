using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool isLooping = false;

    // Use this for initialization
    IEnumerator Start() 
	{
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (isLooping);
	}
	
	// Update is called once per frame
	void Update() 
	{
		
	}

    private IEnumerator SpawnAllWaves()
    {
        for(int i = startingWave; i < waveConfigs.Count; i++)
        {
            var currWave = waveConfigs[i];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig currWave)
    {
        for (int i = 0; i < currWave.getNoOfEnemies(); i++)
        {
            var newEnemy = Instantiate(currWave.getEnemyPrefab(),
                                       currWave.getPathWaypoints()[0].position,
                                       Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(currWave);
            yield return new WaitForSeconds(currWave.getTimeBetweenSpawns());
        }
    }
}
