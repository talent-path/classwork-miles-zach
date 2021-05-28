using System;
using RpgGame.Interfaces;

namespace RpgGame.Abstractions
{
    public abstract class Armor : IArmor
    {
        public Armor()
        {

        }
        public abstract int Durability { get; set; }
        public abstract string Name { get; set; }

        public abstract int ReduceDamage(int incomingDamage);
    }
}
