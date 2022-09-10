using System;

namespace Models
{
    public static class Score
    {
        public static int TotalKills { get; private set; }
        private static int _enemyEasyKills = 0;
        private static int _enemyNormalKills = 0;
        private static int _enemyHardKills = 0;

        public static int TotalPoints {
            get
            {
                int easyKillPoints = _enemyEasyKills * 10;
                int normalKillPoints = _enemyNormalKills * 30;
                int hardKillPoints = _enemyHardKills * 50;

                return easyKillPoints + normalKillPoints + hardKillPoints;
            }
        }

        public static void IncreaseKillByDifficulty(EnemyDifficulty difficulty)
        {
            if (difficulty == EnemyDifficulty.Easy)
            {
                _enemyEasyKills++;
            }
            else if (difficulty == EnemyDifficulty.Normal)
            {
                _enemyNormalKills++;
            }
            else
            {
                _enemyHardKills++;
            }
            TotalKills++;
        }
    }
}
