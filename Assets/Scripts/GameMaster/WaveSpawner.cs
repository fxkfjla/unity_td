using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    // singleton and access build manager without referance
    public static WaveSpawner instance; 

    public Transform redEnemyPrefab;
    public Transform blueEnemyPrefab;
    public Transform spawnPoint;
    public TextMeshProUGUI waveCountdownText;
    public TextMeshProUGUI waveIndexText;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f; // time before it spawns the first wave
    private int waveIndex = 0;

   void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one WaveSpawner in the scene!");
            return;
        }

        instance = this;
    }

    public void SpawnNextWave()
    {
        StartCoroutine(SpawnWave());
        countdown = timeBetweenWaves;
    }

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        // clamping to avoid values less than 0
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.0}", countdown);
        waveIndexText.text = waveIndex.ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for(int i = 0; i < waveIndex; i++)
        {
            SpawnRedEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        if(waveIndex > 9)
        {
            for(int i = 0; i < waveIndex - 9; i++)
            {
                SpawnBlueEnemy();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    void SpawnRedEnemy()
    {
        Instantiate(redEnemyPrefab, spawnPoint.position, spawnPoint.rotation); // clones the enemyPrefab and returns the clone
    }

    void SpawnBlueEnemy()
    {
        Instantiate(blueEnemyPrefab, spawnPoint.position, spawnPoint.rotation); // clones the enemyPrefab and returns the clone
    }
}
