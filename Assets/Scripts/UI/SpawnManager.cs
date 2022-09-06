using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesFirstPhase; // three easy, one normal
    public GameObject[] enemiesSecondPhase; // one easy, two normal, one hard
    public GameObject[] enemiesThirdPhase; // one normal, two hard
    public GameObject healthPotion;

    private float initTime;

    Models.EnemySpawner enemySpawner;
    Models.HealthPotionSpawner healthPotionSpawner;

    private void Start()
    {
        initTime = Time.time;

        enemySpawner = new Models.EnemySpawner();
        InvokeRepeating(
            "SpawnEnemy",
            enemySpawner.spawnStart,
            enemySpawner.spawnInterval
        );

        healthPotionSpawner = new Models.HealthPotionSpawner();
        InvokeRepeating(
            "SpawnHealthPotion",
            healthPotionSpawner.spawnStart,
            healthPotionSpawner.spawnInterval
        );
    }

    private void SpawnEnemy()
    {
        var posInfo = GetSpawnPositionInfo(enemySpawner);
        Vector3 pos = posInfo.Item1;
        bool valid = posInfo.Item2;

        if (valid)
        {
            SpawnEnemyByPhase(pos);
        }
        else
        {
            enemySpawner.failedSpawnAttempts++;
        }

        if (enemySpawner.failedSpawnAttempts == enemySpawner.maxFailedSpawnAttempts)
        {
            CancelInvoke("SpawnEnemy");
        }
    }

    private void SpawnHealthPotion()
    {
        var posInfo = GetSpawnPositionInfo(healthPotionSpawner);
        Vector3 pos = posInfo.Item1;
        bool valid = posInfo.Item2;

        if (valid)
        {
            Instantiate(healthPotion, pos, healthPotion.transform.rotation);
        }
        else
        {
            healthPotionSpawner.failedSpawnAttempts++;
        }

        if (healthPotionSpawner.failedSpawnAttempts == healthPotionSpawner.maxFailedSpawnAttempts)
        {
            CancelInvoke("SpawnHealthPotion");
        }
    }

    private (Vector3, bool) GetSpawnPositionInfo(Models.Spawner spawner)
    {
        Vector3 pos = Vector3.zero;
        int spawnAttempts = 0;
        bool valid = false;

        while (!valid && spawnAttempts < spawner.maxSpawnAttempts)
        {
            float x = Random.Range(spawner.bottomRange, spawner.topRange);
            float z = Random.Range(spawner.bottomRange, spawner.topRange);
            pos = new Vector3(x, spawner.fixedVerticalPos, z);
            spawnAttempts++;

            Collider[] hitColliders = Physics.OverlapSphere(
                pos,
                spawner.overlapCheckRadius
            );

            if (hitColliders.Length == 0)
            {
                valid = true;
            }
        }

        return (pos, valid);
    }

    private void SpawnEnemyByPhase(Vector3 pos)
    {
        float currentTime = Time.time;
        float secondPhaseStart = initTime + enemySpawner.firstPhaseDuration;
        float thirdPhaseStart = initTime + enemySpawner.firstPhaseDuration + enemySpawner.secondPhaseDuration;

        if (currentTime < secondPhaseStart)
        {
            int i = Random.Range(0, enemiesFirstPhase.Length - 1);
            Instantiate(enemiesFirstPhase[i], pos, enemiesFirstPhase[i].transform.rotation);
        }
        else if (currentTime >= secondPhaseStart && currentTime < thirdPhaseStart)
        {
            int i = Random.Range(0, enemiesSecondPhase.Length - 1);
            Instantiate(enemiesSecondPhase[i], pos, enemiesSecondPhase[i].transform.rotation);
        }
        else
        {
            int i = Random.Range(0, enemiesThirdPhase.Length - 1);
            Instantiate(enemiesThirdPhase[i], pos, enemiesThirdPhase[i].transform.rotation);
        }
    }
}
