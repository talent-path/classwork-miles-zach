using System;
using RpgGame.Abstractions;

namespace RpgGame.Concrete.Armors
{
    public class Helmet : Armor
    {
        public Helmet()
        {
        }

        public override int Durability { get; set; } = 10;
        public override string Name { get; set; } = "Helmet";

        public override int ReduceDamage(int incomingDamage)
        {
            return incomingDamage - 1;
        }
    }
}
