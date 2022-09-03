using System;

namespace Models
{
	public class Projectile
	{
		public float Damage { get; }
		public float Speed { get; }

		public Projectile(float damage, float speed)
		{
			Damage = damage;
			Speed = speed;
		}
	}
}
