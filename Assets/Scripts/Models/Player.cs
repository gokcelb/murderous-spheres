using System;

namespace Models
{
	public class Player
	{
		public float Health { get; private set; }

		public Player()
		{
			Health = 300f;
		}

		public void TakeDamage(float damage)
        {
			Health -= damage;
        }
	}
}

