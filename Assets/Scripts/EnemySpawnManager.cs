using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private int _startingWaveIndex = 0;
    [SerializeField] private List<WaveConfig> _waveConfigs;

    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        for (var waveIndex = _startingWaveIndex; waveIndex < _waveConfigs.Count; waveIndex++)
        {
            WaveConfig currentWaveConfig = _waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesinWave(currentWaveConfig));
        }
    }

    private IEnumerator SpawnAllEnemiesinWave(WaveConfig currentWave)
    {
        for (int enemyCount = 0; enemyCount < currentWave.GetNumberOfEnemies(); enemyCount++)
        {
            var instantiatedEnemy = Instantiate(
                currentWave.GetEnemyPrefab(), 
                currentWave.GetWaypoints().First().transform.position,
                Quaternion.identity);

            var enemyPathing = instantiatedEnemy.GetComponent<EnemyPathing>();
            if (enemyPathing != null)
            {
                enemyPathing.SetWaveConfig(currentWave);
            }
            else
            {
                Debug.LogError("EnemySpawnManager::SpawnAllEnemiesInWave(26) - Enemy Pathing script is missing from Instantiated Enemy");
            }
            
            yield return new WaitForSeconds(currentWave.GetTimeBetweenSpawns());
        }
    }
}
