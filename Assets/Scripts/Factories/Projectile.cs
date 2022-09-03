using System;

namespace Factories
{
	public class Projectile
	{
		protected float damage;
        protected float speed = 30f;

        public Models.Projectile Create()
        {
            return new Models.Projectile(damage, speed);
        }
	}

	public class EnemyEasyProjectile : Projectile
    {
		public EnemyEasyProjectile()
        {
			damage = 50f;
        }
    }

	public class EnemyNormalProjectile : Projectile
    {
		public EnemyNormalProjectile()
        {
			damage = 150f;
        }
    }

	public class EnemyHardProjectile : Projectile
    {
		public EnemyHardProjectile()
        {
            damage = 300f;
        }
    }

    public class PlayerProjectile : Projectile
    {
        public PlayerProjectile()
        {
            damage = 100f;
        }
    }
}

