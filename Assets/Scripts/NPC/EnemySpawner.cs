using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefab;

    private IEnumerator Start()
    {
        while (true) { 
            SpawnRandomEnemy();
            yield return StartCoroutine(SpawnCooldown());
        }
    }

    private void SpawnRandomEnemy()
    {
        int randInt = Random.Range(0, enemyPrefab.Count);
        GameObject randomEnemy = enemyPrefab[randInt];
        Instantiate(randomEnemy, transform.position, Quaternion.identity, transform);
    }

    private IEnumerator SpawnCooldown()
    {
        float delayUntilNextEnemySpawn = Random.Range(8, 16);
        yield return new WaitForSecondsRealtime(delayUntilNextEnemySpawn);
    }

}
