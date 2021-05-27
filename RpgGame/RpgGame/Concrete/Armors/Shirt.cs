using System;
using RpgGame.Abstractions;

namespace RpgGame.Concrete.Armors
{
    public class Shirt : Armor
    {
        public Shirt()
        {
        }

        public override int Durability { get; set; } = 10;
        public override string Name { get; set; } = "Shirt";

        public override int ReduceDamage(int incomingDamage)
        {
            return incomingDamage - 1;
        }
    }
}
