using System;

namespace Factories
{
	public class Enemy
    {
		protected float health;
		protected float shootingSpeed = 1f;

		public Models.Enemy Create()
        {
			return new Models.Enemy(health, shootingSpeed);

		}
	}

	public class EnemyEasy : Enemy
	{
		public EnemyEasy()
        {
			health = 100f;
        }
	}

	public class EnemyNormal : Enemy
	{
		public EnemyNormal()
        {
			health = 150f;
        }
	}

	public class EnemyHard : Enemy
	{
		public EnemyHard()
        {
			health = 300f;
        }
	}
}

