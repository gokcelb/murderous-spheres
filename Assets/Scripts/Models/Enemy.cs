using System;

namespace Models
{
	public class Enemy
	{
		public float Health { get; private set; }
		public float ShootingSpeed { get; private set; }

		public Enemy(float health, float shootingSpeed)
        {
			Health = health;
			ShootingSpeed = shootingSpeed;
        }

		public void TakeDamage(float damage)
        {
			Health -= damage;
        }
	}
}
