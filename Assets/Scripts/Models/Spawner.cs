using System;

namespace Models
{
    public abstract class Spawner
    {
        public float spawnStart;
        public float spawnInterval;
        public int maxSpawnAttempts = 10;
        public int maxFailedSpawnAttempts = 10;
        public int failedSpawnAttempts = 0;

        public float fixedVerticalPos;
        public float overlapCheckRadius;
        public float topRange;
        public float bottomRange;
        public float rightRange;
        public float leftRange;
    }

    public class EnemySpawner : Spawner
    {
        public float firstPhaseDuration;
        public float secondPhaseDuration;

        public EnemySpawner()
        {
            spawnStart = 1f;
            spawnInterval = 3f;

            fixedVerticalPos = 3f;
            overlapCheckRadius = 2.5f;
            topRange = 20f;
            bottomRange = 0f;
            rightRange = 12f;
            leftRange = -12f;

            firstPhaseDuration = 5f;
            secondPhaseDuration = 10f;
        }
    }

    public class HealthPotionSpawner : Spawner
    {
        public HealthPotionSpawner()
        {
            spawnStart = 5f;
            spawnInterval = 7f;

            fixedVerticalPos = 2f;
            overlapCheckRadius = 1f;
            topRange = 0f;
            bottomRange = -20f;
            rightRange = 12f;
            leftRange = -12f;
        }
    }
}
