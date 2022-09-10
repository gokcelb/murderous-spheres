using System;

namespace Models
{
	public abstract class Projectile
	{
		protected float _speed = 30f;

		public float Speed
		{
			get => _speed;
		}

		public float Damage { get; protected set; }
	}

	public class ProjectileEnemyEasy : Projectile
	{
		public ProjectileEnemyEasy()
		{
			Damage = 50f;
		}
	}

	public class ProjectileEnemyNormal : Projectile
	{
		public ProjectileEnemyNormal()
		{
			Damage = 150f;
		}
	}

	public class ProjectileEnemyHard : Projectile
	{
		public ProjectileEnemyHard()
		{
			Damage = 300;
		}
	}

	public class ProjectilePlayer : Projectile
	{
		public ProjectilePlayer()
		{
			Damage = 100f;
		}
	}
}
