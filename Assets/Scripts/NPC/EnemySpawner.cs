using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefab;
    private List<GameObject> enemiesSpawned; // prevents having more than 4 enemies present at once;

    public int maxEnemies;

    private IEnumerator Start()
    {
        while (true) { 
            SpawnRandomEnemy();
            yield return StartCoroutine(SpawnCooldown());
        }
    }

    private void SpawnRandomEnemy()
    {
        if (!CanSpawnEnemy()) {
            return;
        }
        int randInt = Random.Range(0, enemyPrefab.Count);
        GameObject randomEnemy = enemyPrefab[randInt];
        Instantiate(randomEnemy, transform.position, Quaternion.identity, transform);
    }

    private bool CanSpawnEnemy()
    {
        return transform.childCount < maxEnemies;
    }

    private IEnumerator SpawnCooldown()
    {
        float delayUntilNextEnemySpawn = Random.Range(8, 16);
        yield return new WaitForSecondsRealtime(delayUntilNextEnemySpawn);
    }

}
