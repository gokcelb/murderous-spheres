using System;

namespace Models
{
    public class HealthPotion
    {
        public float Heal { get; private set; }

        public HealthPotion()
        {
            Heal = 100f;
        }
    }
}
