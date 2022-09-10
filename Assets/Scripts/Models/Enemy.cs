using System;

namespace Models
{
	public enum EnemyDifficulty
    {
        Easy,
        Normal,
        Hard
    }

  	public abstract class Enemy
  	{
		protected float _shootingSpeed = 1f;

		public float ShootingSpeed
		{
			get => _shootingSpeed;
		}

    	public float Health { get; protected set; }

		public void TakeDamage(float damage)
		{
			Health -= damage;
		}
  	}

	public class EnemyEasy : Enemy
	{
		public EnemyEasy()
		{
			Health = 150f;
		}
	}

	public class EnemyNormal : Enemy
	{
		public EnemyNormal()
		{
			Health = 300f;
		}
	}

	public class EnemyHard : Enemy
	{
		public EnemyHard()
		{
			Health = 300f;
		}
	}
}
