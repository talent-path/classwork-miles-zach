using System;
using RpgGame.Abstractions;

namespace RpgGame.Concrete.Armors
{
    public class Shield : Armor
    {
        public Shield()
        {
        }

        public override int Durability { get; set; } = 10;
        public override string Name { get; set; } = "Shield";

        public override int ReduceDamage(int incomingDamage)
        {

            if (Durability == 0)
                return incomingDamage;

            Random random = new Random();
            int x = random.Next(0, 2);
            if (x == 0)
                incomingDamage = 0;

            int y = random.Next(1, 21);
            if (y == 15)
                Durability -= 1;

            return incomingDamage;
        }
    }
}
